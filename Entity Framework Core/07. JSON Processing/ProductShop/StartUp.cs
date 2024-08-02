using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            //Task1
            //string usersList = File.ReadAllText("../../../Datasets/users.json");
            //Console.WriteLine(ImportUsers(context, usersList));

            //Task2
            //string productsList = File.ReadAllText("../../../Datasets/products.json");
            //Console.WriteLine(ImportProducts(context, productsList));

            //Task3
            //string categoriesList = File.ReadAllText("../../../Datasets/categories.json");
            //Console.WriteLine(ImportCategories(context, categoriesList));

            //Task4
            //string catProList = File.ReadAllText("../../../Datasets/categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(context, catProList));

            Console.WriteLine(GetUsersWithProducts(context));
        }

        //Task 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithSoldProduct = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.BuyerId != null && ps.Price != null))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = u.ProductsSold
                    .Where(p => p.BuyerId != null && p.Price != null)
                    .Select(ps => new
                    {
                        ps.Name,
                        ps.Price
                    })
                    .ToArray()
                })
                .OrderByDescending(u => u.SoldProducts.Length)
                .ToArray();

            var output = new
            {
                UsersCount = usersWithSoldProduct.Length,
                Users = usersWithSoldProduct.Select(up => new
                {
                    up.FirstName,
                    up.LastName,
                    up.Age,
                    SoldProducts = new
                    {
                        Count = up.SoldProducts.Length,
                        Products = up.SoldProducts
                    }
                })
            };

            return SerializeObjectWithJsonSettings(output);
        }

        //Task 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoriesProducts.Count)
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoriesProducts.Count,
                    AveragePrice = Math.Round(c.CategoriesProducts.Select(cp => cp.Product.Price).Average(), 2).ToString("f2"),
                    TotalRevenue = Math.Round(c.CategoriesProducts.Select(cp => cp.Product.Price).Sum(), 2).ToString("f2")
                });


            return SerializeObjectWithJsonSettings(categories);
        }

        //Task 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            var sellers = context.Users
                .Where(s => s.ProductsSold.Any(ps => ps.BuyerId != null))
                .Select(s => new
                {
                    s.FirstName,
                    s.LastName,
                    SoldProducts = s.ProductsSold.Select(ps => new
                    {
                        ps.Name,
                        ps.Price,
                        BuyerFirstName = ps.Buyer.FirstName,
                        BuyerLastName = ps.Buyer.LastName
                    })
                })
                .OrderBy(s => s.LastName)
                .ThenBy(s => s.FirstName)
                .ToArray();

            return SerializeObjectWithJsonSettings(sellers);
        }


        //Task 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            var contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = contractResolver
            };

            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToArray();

            var jsonProducts = JsonConvert.SerializeObject(productsInRange, jsonSerializerSettings);

            return jsonProducts;
        }

        //Task 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);
            context.CategoriesProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //Task 3
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson);

            categories.RemoveAll(c => c.Name == null);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Task 2
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Task 1
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }


        private static string SerializeObjectWithJsonSettings(object obj)
        {
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}