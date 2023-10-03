using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.RawData
{
    public class Tire
    {
        public Tire(float pressure, int age)
        {
            Age = age;
            Pressure = pressure;
        }
        
        public int age;
        public float pressure;

        public int Age { get; set; }
        public float Pressure { get; set; }
    }
}
