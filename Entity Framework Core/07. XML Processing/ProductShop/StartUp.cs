using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            string usersList = File.ReadAllText("../../../Datasets/users.json");

            ImportUsers(context, usersList);
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            User[] users = JsonConvert.DeserializeObject<User[]>(inputJson);

            return $"Successfully imported {3}";
        }
    }
}