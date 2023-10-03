using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.RawData
{
    public  class Cargo
    {
        public Cargo(int weight, string type)
        {
            Type = type;
            Weight = weight;
        }

        private string type;
        private int weight;

        public string Type { get; set; }
        public int Weight { get; set; }
    }
}
