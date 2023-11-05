using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BorderControl
{
    public class Robots : ICheckID
    {
        public Robots(string name, string iD)
        {
            Name = name;
            ID = iD;
        }

        public string Name { get; set; }
        public string ID { get; set; }

        public bool IsValidID(string id) => ID == id;
    }
}
