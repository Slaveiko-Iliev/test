using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            string supliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            string partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            string carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            string customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            string salesXml = File.ReadAllText("../../../Datasets/sales.xml");

            using (CarDealerContext context = new CarDealerContext())
            {
                //Console.WriteLine(ImportSuppliers(context, supliersXml));
                //Console.WriteLine(ImportParts(context, partsXml));
                //Console.WriteLine(ImportCars(context, carsXml));
                //Console.WriteLine(ImportCustomers(context, customersXml));
                //Console.WriteLine(ImportSales(context, salesXml));
                Console.WriteLine(GetSalesWithAppliedDiscount(context));
            }
        }

        //Task 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new SaleWithDiscount()
                {
                    Car = new CarDto()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    Discount = (int)s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars
                        .Sum(pc => pc.Part.Price),
                    PriceWithDiscount = Math.Round(
                        (double)(s.Car.PartsCars.Sum(p => p.Part.Price)
                                 * (1 - (s.Discount / 100))), 4)
                }).ToArray();

            return SerializeToXml(sales, "sales");
        }

        //Task 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var temp = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SalesInfo = c.Sales.Select(s => new
                    {
                        Prices = c.IsYoungDriver
                        ? s.Car.PartsCars.Sum(pc => Math.Round((double)pc.Part.Price * 0.95, 2))
                        : s.Car.PartsCars.Sum(pc => (double)pc.Part.Price)
                    }).ToArray()
                }).ToArray();

            var customers = temp
                .Select(t => new ExportSalesByCustomer()
                {
                    FullName = t.FullName,
                    BoughtCars = t.BoughtCars,
                    SpentMoney = t.SalesInfo.Sum(si => (decimal)si.Prices)
                })
                .OrderByDescending(t => t.SpentMoney)
                .ToArray();

            return SerializeToXml(customers, "customers");
        }

        //Task 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            ExportCarsWithParts[] cars = context.Cars
                .Select(car => new ExportCarsWithParts()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TraveledDistance = car.TraveledDistance,
                    Parts = car.PartsCars
                        .Select(pc => new PartDto()
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                })
                .OrderByDescending(car => car.TraveledDistance)
                .ThenBy(car => car.Model)
                .Take(5)
                .ToArray();

            return SerializeToXml(cars, "cars");
        }

        //Task 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            LocalExportDto[] localSuppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new LocalExportDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            return SerializeToXml(localSuppliers, "suppliers");
        }

        //Task 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            BmvExportDto[] dtos = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new BmvExportDto()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToArray();

            return SerializeToXml(dtos, "cars");
        }

        //Task 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            CarsExportDto[] carsWithDistance = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .Select(c => new CarsExportDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            return SerializeToXml(carsWithDistance, "cars");
        }

        //Task 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SalesImportDto[]), new XmlRootAttribute("Sales"));

            using StringReader reader = new StringReader(inputXml);

            SalesImportDto[] salesDtos = (SalesImportDto[])serializer.Deserialize(reader);

            int[] validCarId = context.Cars
                .Select(c => c.Id)
                .ToArray();

            List<Sale> sales = salesDtos
                .Where(sd => validCarId.Contains(sd.CarId))
                .Select(sd => new Sale()
                {
                    Discount = sd.Discount,
                    CarId = sd.CarId,
                    CustomerId = sd.CustomerId
                })
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //Task 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CustomersImportDto[]), new XmlRootAttribute("Customers"));

            using StringReader reader = new StringReader(inputXml);
            CustomersImportDto[] customersDtos = (CustomersImportDto[])serializer.Deserialize(reader);

            List<Customer> customers = customersDtos
                .Select(cd => new Customer()
                {
                    Name = cd.Name,
                    BirthDate = cd.BirthDate,
                    IsYoungDriver = cd.IsYoungDriver
                })
                .ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        //Task 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CarsImportDto[]), new XmlRootAttribute("Cars"));

            CarsImportDto[] importDtos;

            using (StringReader reader = new StringReader(inputXml))
            {
                importDtos = (CarsImportDto[])serializer.Deserialize(reader);
            }

            List<Car> cars = new List<Car>();

            var validPartIds = context.Parts
                .Select(part => part.Id)
                .ToList();

            foreach (var dto in importDtos)
            {
                Car car = new Car()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TraveledDistance = dto.TraveledDistance
                };

                int[] partIds = dto.PartIds
                    .Select(x => x.Id)
                    .Distinct()
                    .ToArray();

                List<PartCar> partsCars = new List<PartCar>();

                foreach (int id in partIds)
                {
                    if (validPartIds.Contains(id))
                    {
                        PartCar partCar = new PartCar()
                        {
                            Car = car,
                            PartId = id
                        };

                        partsCars.Add(partCar);
                    }
                }

                car.PartsCars = partsCars;

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //Task 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PartsImportDto[]), new XmlRootAttribute("Parts"));

            PartsImportDto[] partsDtos;

            using (StringReader reader = new StringReader(inputXml))
            {
                partsDtos = (PartsImportDto[])serializer.Deserialize(reader);
            }

            var supplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToArray();

            var validPartsDto = partsDtos
                .Where(vpd => supplierIds.Contains(vpd.SupplierId))
                .ToArray();


            Part[] parts = validPartsDto
                .Select(part => new Part()
                {
                    Name = part.Name,
                    Price = part.Price,
                    Quantity = part.Quantity,
                    SupplierId = part.SupplierId
                })
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        //Task 9
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(SuppliersImportDto[]), new XmlRootAttribute("Suppliers"));

            SuppliersImportDto[] importSuppliersDtos;

            using (StringReader reader = new StringReader(inputXml))
            {
                importSuppliersDtos = (SuppliersImportDto[])serializer.Deserialize(reader);
            }

            Supplier[] suppliers = importSuppliersDtos
                .Select(isd => new Supplier
                {
                    Name = isd.Name,
                    IsImporter = isd.IsImporter
                })
                .ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        private static string SerializeToXml<T>(T dto, string xmlRootAttribute, bool omitDeclaration = false)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));
            StringBuilder stringBuilder = new StringBuilder();

            XmlWriterSettings settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = omitDeclaration,
                Encoding = new UTF8Encoding(false),
                Indent = true
            };

            using (StringWriter stringWriter = new StringWriter(stringBuilder, CultureInfo.InvariantCulture))
            using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
            {
                XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
                xmlSerializerNamespaces.Add(string.Empty, string.Empty);

                try
                {
                    xmlSerializer.Serialize(xmlWriter, dto, xmlSerializerNamespaces);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return stringBuilder.ToString();
        }
    }

}