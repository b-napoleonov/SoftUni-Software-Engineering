using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs;
using ProductShop.Models;
using System;
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

            //string usersJson = File.ReadAllText("../../../Datasets/users.json");
            //string productsJson = File.ReadAllText("../../../Datasets/products.json");
            //string categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            //string categoriesProductsJson = File.ReadAllText("../../../Datasets/categories-products.json");

            //ImportUsers(context, usersJson);
            //ImportProducts(context, productsJson);
            //ImportCategories(context, categoriesJson);
            //ImportCategoryProducts(context, categoriesProductsJson);
            Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x => x.ProductsSold)
                .ToList()
                .Where(u => u.ProductsSold.Any(b => b.BuyerId != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Where(x => x.BuyerId != null).Count(),
                        products = u.ProductsSold.Where(x => x.BuyerId != null).Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        })
                    }
                })
                .OrderByDescending(u => u.soldProducts.products.Count())
                .ToList();

            var resultObject = new
            {
                usersCount = users.Count(),
                users = users
            };

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            };

            var usersJson = JsonConvert.SerializeObject(resultObject, Formatting.Indented, jsonSerializerSettings);

            return usersJson;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = c.CategoryProducts.Count == 0
                        ? $"{0:F2}"
                        : c.CategoryProducts.Average(p => p.Product.Price).ToString("F2"),
                    totalRevenue = c.CategoryProducts.Sum(p => p.Product.Price).ToString("F2")
                })
                .OrderByDescending(c => c.productsCount)
                .ToList();

            var categoriesJson = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return categoriesJson;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold.Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName,
                    })
                })
                .OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName)
                .ToList();

            var usersJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            
            return usersJson;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName,
                })
                .OrderBy(p => p.price)
                .ToList();

            var productsJson = JsonConvert.SerializeObject(products, Formatting.Indented);

            return productsJson;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoCategoriesProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProductDTO>>(inputJson);

            var categoriesProducts = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategoriesProducts);

            context.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoCategories = JsonConvert.DeserializeObject<IEnumerable<CategoryDTO>>(inputJson);

            var categories = mapper.Map<IEnumerable<Category>>(dtoCategories).Where(c => c.Name != null);

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(inputJson);

            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }


        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserDTO>>(inputJson);

            var users = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.AddRange(users);
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