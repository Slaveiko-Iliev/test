using _01.Vehicles.Core;
using _01.Vehicles.Core.Interfaces;

namespace _02.VehiclesExtension
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
