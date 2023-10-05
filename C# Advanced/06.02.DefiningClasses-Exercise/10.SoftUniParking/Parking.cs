using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            cars = new Dictionary<string, Car>();
        }

        public List<Car> Cars { get; set; }
    }

    //public string AddCar(Car Car)
    //{
    //    if (Capa)
    //    {

    //    }
    //}
}
