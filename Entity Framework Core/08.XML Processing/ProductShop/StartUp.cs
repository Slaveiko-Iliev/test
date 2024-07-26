using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            //string usersXml = File.ReadAllText("../../../Datasets/users.xml");
            //Console.WriteLine(ImportUsers(context, usersXml));

            //string productsXml = File.ReadAllText("../../../Datasets/products.xml");
            //Console.WriteLine(ImportProducts(context, productsXml));

            //string categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            //Console.WriteLine(ImportCategories(context, categoriesXml));

            //string categoriesProducts = File.ReadAllText("../../../Datasets/categories-products.xml");
            //Console.WriteLine(ImportCategoryProducts(context, categoriesProducts));

            Console.WriteLine(GetCategoriesByProductsCount(context));
        }

        //Task 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {


            return "";
        }

        //Task 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            CategoriesWithProductsCount[] categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .ThenBy(c => c.CategoryProducts.Sum(cp => cp.Product.Price))
                .Select(c => new CategoriesWithProductsCount()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .ToArray();

            return SerializeToXml(categories, "Categories");
        }

        //Task 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .Select(u => new UserWithSoldProducts()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Select(ps => new SoldProduct()
                        {
                            Name = ps.Name,
                            Price = ps.Price
                        }).ToArray()
                })
                .ToArray();

            return SerializeToXml(users, "Users");
        }

        //Task 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            ExportProductsInRangeDto[] products = context.Products
                .Where(p => p.Price >= 500
                            && p.Price <= 1000)
                .Select(p => new ExportProductsInRangeDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer != null ? $"{p.Buyer.FirstName} {p.Buyer.LastName}" : null
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();

            return SerializeToXml(products, "Products");
        }

        //Task 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer
                = new XmlSerializer(typeof(CategoriesProductsImportDto[]), new XmlRootAttribute("CategoryProducts"));

            using StringReader xmlReader
                = new StringReader(inputXml);

            CategoriesProductsImportDto[] categoriesProductsImportDtos = (CategoriesProductsImportDto[])xmlSerializer.Deserialize(xmlReader);

            int[] validProductIds = context.Products
                .Select(p => p.Id)
                .ToArray();

            int[] validCategoryIds = context.Categories
                .Select(p => p.Id)
                .ToArray();

            CategoryProduct[] categoryProducts = categoriesProductsImportDtos
                .Where(cpid => validProductIds.Contains(cpid.ProductId)
                                && validCategoryIds.Contains(cpid.CategoryId))
                .Select(cpid => new CategoryProduct()
                {
                    CategoryId = cpid.CategoryId,
                    ProductId = cpid.ProductId,
                })
                .ToArray();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }

        //Task 3
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer
                = new XmlSerializer(typeof(CategoriesImportDto[]), new XmlRootAttribute("Categories"));

            using StringReader xmlReader
                = new StringReader(inputXml);

            CategoriesImportDto[] categoriesImportDtos
                = (CategoriesImportDto[])serializer.Deserialize(xmlReader);

            Category[] categories
                = categoriesImportDtos
                .Select(cid => new Category()
                {
                    Name = cid.Name
                })
                .ToArray();

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        //Task 2
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer
                = new XmlSerializer(typeof(ProductImportDto[]), new XmlRootAttribute("Products"));

            ProductImportDto[] deserializedProducts;

            using (StringReader reader = new StringReader(inputXml))
            {
                deserializedProducts =
                    (ProductImportDto[])serializer.Deserialize(reader);
            }

            Product[] products = deserializedProducts
                    .Select(dp => new Product
                    {
                        Name = dp.Name,
                        Price = dp.Price,
                        SellerId = dp.SellerId,
                        BuyerId = dp.BuyerId
                    })
                    .ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        //Task 1
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer =
                new XmlSerializer(typeof(UserImportDto[]), new XmlRootAttribute("Users"));

            UserImportDto[] deserializedUsers;

            using (StringReader reader = new StringReader(inputXml))
            {
                deserializedUsers =
                    (UserImportDto[])serializer.Deserialize(reader);
            }

            User[] users = deserializedUsers
                .Select(ds => new User
                {
                    FirstName = ds.FirstName,
                    LastName = ds.LastName,
                    Age = ds.Age
                })
                .ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        private static string SerializeToXml<T>(T dto, string xmlRootAttribute)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));

            StringBuilder stringBuilder = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(stringBuilder, CultureInfo.InvariantCulture))
            {
                XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
                xmlSerializerNamespaces.Add(string.Empty, string.Empty);

                try
                {
                    xmlSerializer.Serialize(stringWriter, dto, xmlSerializerNamespaces);
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