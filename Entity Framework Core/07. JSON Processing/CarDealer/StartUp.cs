using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.Models;
using Newtonsoft.Json;
using System.Globalization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //var inputCars = File.ReadAllText("../../../Datasets/cars.json");
            //Console.WriteLine(ImportCars(context, inputCars));

            //var inputCustomers = File.ReadAllText("../../../Datasets/customers.json");
            //Console.WriteLine(ImportCustomers(context, inputCustomers));

            //var inputParts = File.ReadAllText("../../../Datasets/parts.json");
            //Console.WriteLine(ImportParts(context, inputParts));

            //var inputSales = File.ReadAllText("../../../Datasets/sales.json");
            //Console.WriteLine(ImportSales(context, inputSales));

            //var inputSuppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            //Console.WriteLine(ImportSuppliers(context, inputSuppliers));

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        //Task 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales.Select(s => new
            {
                car = new
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TravelledDistance = s.Car.TraveledDistance
                },
                customerName = s.Customer.Name,
                Discount = s.Discount.ToString("f2"),
                price = s.Car.PartsCars.Sum(pc => pc.Part.Price).ToString("f2"),
                priceWithDiscount = ((s.Car.PartsCars.Sum(pc => pc.Part.Price)) * (1 - s.Discount * 0.01m))
                .ToString("f2")
            }).Take(10).ToList();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }

        //public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        //{
        //    var firstTenSales = context.Sales
        //        .Take(10)
        //        .Select(s => new
        //        {
        //            car = new
        //            {
        //                s.Car.Make,
        //                s.Car.Model,
        //                s.Car.TraveledDistance
        //            },
        //            customerName = s.Customer.Name,
        //            discount = $"{s.Discount:f2}",
        //            price = $"{s.Car.PartsCars.Sum(pc => pc.Part.Price):f2}",
        //            priceWithDiscount = $"{(1 - s.Discount / 10) * s.Car.PartsCars.Sum(pc => pc.Part.Price):f2}"
        //        })
        //        .ToArray();

        //    return SerializeObjectWithJsonSettings(firstTenSales);
        //}

        //Task 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count() > 0)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count(),
                    spentMoney = c.Sales.Sum(s => s.Car.PartsCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToArray();

            var jsonFile = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return jsonFile;
        }

        //public static string GetTotalSalesByCustomer(CarDealerContext context)
        //{
        //    var sales = context.Sales
        //        .Select(s => new
        //        {
        //            FullName = s.Customer.Name,
        //            BoughtCars = s.Customer.Sales.Count,
        //            SpentMoney = s.Car.PartsCars.Sum(pc => pc.Part.Price)
        //        })
        //        .OrderByDescending(s => s.SpentMoney)
        //        .ThenByDescending(s => s.BoughtCars)
        //        .ToArray();

        //    return SerializeObjectWithJsonSettings(sales);
        //}

        //Task 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TraveledDistance
                    },
                    parts = c.PartsCars.Select(pc => new
                    {
                        pc.Part.Name,
                        Price = pc.Part.Price.ToString("f2")
                    }).ToArray()
                })
                .ToArray();

            return SerializeObjectWithJsonSettings(cars);
        }

        //Task 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(ls => !ls.IsImporter)
                .Select(ls => new ExportSuppliersDto()
                {
                    Id = ls.Id,
                    Name = ls.Name,
                    PartsCount = ls.Parts.Count
                });

            return SerializeObjectWithJsonSettings(localSuppliers);
        }

        //Task 15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TraveledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToArray();

            return SerializeObjectWithJsonSettings(cars);
        }

        //Task 14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenByDescending(c => !c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    c.IsYoungDriver
                })
                .ToArray();

            return SerializeObjectWithJsonSettings(customers);
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<List<Car>>(inputJson);

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .Where(p => context.Suppliers.Select(s => s.Id).Contains(p.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        private static string SerializeObjectWithJsonSettings(object obj)
        {
            var settings = new JsonSerializerSettings()
            {
                //ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
                //NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}