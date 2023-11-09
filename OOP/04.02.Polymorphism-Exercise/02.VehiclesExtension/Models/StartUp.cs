using _01.Vehicles.Core;
using _01.Vehicles.Core.Interfaces;

namespace _01.Vehicles.Models
{
    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
