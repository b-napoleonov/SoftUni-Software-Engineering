using AutoMapper;
using Newtonsoft.Json.Linq;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.XMLFacade;
using Remotion.Linq.Clauses;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //string usersXml = File.ReadAllText("../../../Datasets/users.xml");
            //string productsXml = File.ReadAllText("../../../Datasets/products.xml");
            //string categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            //string categoriesProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");

            //ImportUsers(context, usersXml);
            //ImportProducts(context, productsXml);
            //ImportCategories(context, categoriesXml);
            //ImportCategoryProducts(context, categoriesProductsXml);

            var result = GetUsersWithProducts(context);
            System.Console.WriteLine(result);
        }

        //Problem 8 - Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            const string root = "Users";

            var users = context.Users
                .ToList()
                .Where(u => u.ProductsSold.Any())
                .Select(u => new ExportUserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProduct = new ExportProductCountDto
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(ps => new ExportProductDto
                        {
                            Name = ps.Name,
                            Price = ps.Price,
                        })
                        .OrderByDescending(p => p.Price)
                        .ToList()
                    }
                })
                .OrderByDescending(x => x.SoldProduct.Count)
                .Take(10)
                .ToList();

            var resultDTO = new ExportUserCountDto
            {
                Count = context.Users.Count(p => p.ProductsSold.Any()),
                Users = users,
            };

            return XmlConverter.Serialize(resultDTO, root);
        }

        //Problem 7 - Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            const string root = "Categories";

            var categories = context.Categories
                .Select(c => new CategoryExportModel
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price),
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToList();

            return XmlConverter.Serialize(categories, root);
        }

        //Problem 6 - Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            const string root = "Users";

            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new UserOutputModel
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                                        .Select(ps => new UserProductExportModel
                                        {
                                            Name = ps.Name,
                                            Price = ps.Price,
                                        })
                                        .ToList()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToList();

            return XmlConverter.Serialize(users, root);
        }

        //Problem 5 - Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            const string root = "Products";

            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductExportModel
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName,
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToList();

            return XmlConverter.Serialize(products, root);
        }

        //Problem 4 - Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            const string root = "CategoryProducts";
            InitializeAutoMapper();

            var categoryIds = context.Categories.Select(c => c.Id);
            var productIds = context.Products.Select(p => p.Id);

            var categoriesProductsDTO = XmlConverter.Deserializer<CategoryProductDTO>(inputXml, root);
            var categoriesProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoriesProductsDTO)
                .Where(x => categoryIds.Contains(x.CategoryId) &&
                            productIds.Contains(x.ProductId));

            context.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count()}";
        }

        //Problem 3 - Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string root = "Categories";
            InitializeAutoMapper();

            var categoriesDTO = XmlConverter.Deserializer<CategoryDTO>(inputXml, root);
            var categories = mapper.Map<IEnumerable<Category>>(categoriesDTO)
                .Where(c => c.Name != null)
                .ToList();

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        //Problem 2 - Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string root = "Products";
            InitializeAutoMapper();

            var productsDTO = XmlConverter.Deserializer<ProductDTO>(inputXml, root);

            var products = mapper.Map<IEnumerable<Product>>(productsDTO);

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        //Problem 1 - Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string root = "Users";
            InitializeAutoMapper();

            var usersDTO = XmlConverter.Deserializer<UserDTO>(inputXml, root);

            //Without AutoMapper

            //var users = usersDTO.Select(u => new User
            //{
            //    FirstName = u.FirstName,
            //    LastName = u.LastName,
            //    Age = u.Age,
            //})
            //    .ToList();

            //With AutoMapper

            var users = mapper.Map<IEnumerable<User>>(usersDTO);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}