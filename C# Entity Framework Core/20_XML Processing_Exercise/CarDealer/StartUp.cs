using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using CarDealer.XMLFacade;
using System.Collections.Generic;
using System.Linq;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //string suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //string partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            //string carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            //string customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            //string salesXml = File.ReadAllText("../../../Datasets/sales.xml");

            //ImportSuppliers(context, suppliersXml);
            //ImportParts(context, partsXml);
            //ImportCars(context, carsXml);
            //ImportCustomers(context, customersXml);

            var result = GetSalesWithAppliedDiscount(context);

            System.Console.WriteLine(result);
        }

        //Problem 19 - Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            const string root = "sales";

            var sales = context.Sales
                .Select(s => new SaleWithDiscountExportModel
                {
                    Car = new CarSaleExportModel
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance,
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(c => c.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(c => c.Part.Price) - s.Car.PartCars.Sum(c => c.Part.Price) * s.Discount / 100
                })
                .ToList();

            return XmlConverter.Serialize(sales, root);
        }

        //Problem 18 - Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            const string root = "customers";

            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new SaleByCustomerExportModel
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.SelectMany(s => s.Car.PartCars).Sum(x => x.Part.Price),
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToList();

            return XmlConverter.Serialize(customers, root);
        }

        //Problem 17 - Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            const string root = "cars";

            var carsParts = context.Cars
                .Select(c => new PartCarExportModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(pc => new PartExportModel
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price,
                    })
                    .OrderByDescending(pc => pc.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToList();

            return XmlConverter.Serialize(carsParts, root);
        }

        //Problem 16 - Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            const string root = "suppliers";

            var localSuppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new LocalSupplierExportModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartCount = s.Parts.Count,
                })
                .ToList();

            return XmlConverter.Serialize(localSuppliers, root);
        }

        //Problem 15 - Export Cars from make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            const string root = "cars";

            var bmwCars = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new CarBMWExportModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            return XmlConverter.Serialize(bmwCars, root);
        }

        //Problem 14 - Export Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            const string root = "cars";

            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2_000_000)
                .Select(c => new CarExportModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToList();

            return XmlConverter.Serialize(cars, root);
        }

        //Problem 13 - Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            const string root = "Sales";
            InitializeAutoMapper();

            var salesDTO = XmlConverter.Deserializer<SaleDTO>(inputXml, root);

            var carIds = context.Cars.Select(x => x.Id).ToList();
            var sales = mapper.Map<IEnumerable<Sale>>(salesDTO)
                .Where(c => carIds.Contains(c.CarId));

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }

        //Problem 12 - Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            const string root = "Customers";
            InitializeAutoMapper();

            var customersDTO = XmlConverter.Deserializer<CustomerDTO>(inputXml, root);
            var customers = mapper.Map<IEnumerable<Customer>>(customersDTO);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }

        //Problem 11 - Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            const string root = "Cars";

            var carsDTO = XmlConverter.Deserializer<CarDTO>(inputXml, root);
            
            var partIds = context.Parts.Select(x => x.Id).ToList();
            var cars = carsDTO
                .Select(c => new Car
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TraveledDistance,
                    PartCars = c.Parts.Select(x => x.Id)
                    .Distinct()
                    .Intersect(partIds)
                    .Select(pc => new PartCar
                    {
                        PartId = pc,
                    })
                    .ToList()
                })
                .ToList();

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }

        //Problem 10 - Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            const string root = "Parts";
            InitializeAutoMapper();

            var supplierIds = context.Suppliers.Select(x => x.Id).ToList();

            var partsDTO = XmlConverter.Deserializer<PartDTO>(inputXml, root);
            var parts = mapper.Map<IEnumerable<Part>>(partsDTO)
                .Where(p => supplierIds.Contains(p.SupplierId));

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }

        //Problem 9 - Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            const string root = "Suppliers";
            InitializeAutoMapper();

            var suppliersDTO = XmlConverter.Deserializer<SupplierDTO>(inputXml, root);
            var suppliers = mapper.Map<IEnumerable<Supplier>>(suppliersDTO);

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}