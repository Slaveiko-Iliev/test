using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Tuple
{
    public class StartUp
    {
        public static void Main()
        {
            string[] nameAddress = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = $"{nameAddress[0]} {nameAddress[1]}";
            string address = nameAddress[2];

            MakeTuple<string, string> nameWithAddress = new (name, address);

            Console.WriteLine(nameWithAddress.ToString());


            string[] nameBeer = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            name = nameBeer[0];
            int litersOfBeer = int.Parse(nameBeer[1]);

            MakeTuple<string, int> nameWithBeer = new(name, litersOfBeer);

            Console.WriteLine(nameWithBeer.ToString());


            string[] intDoubler = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int integer = int.Parse(intDoubler[0]);
            double doubl = double.Parse(intDoubler[1]);

            MakeTuple<int, double> intWIthDouble = new(integer, doubl);

            Console.WriteLine(intWIthDouble.ToString());
        }
    }
}
