using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Threeuple
{
    public class StartUp
    {
        public static void Main()
        {
            string[] nameAddress = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = $"{nameAddress[0]} {nameAddress[1]}";
            string address = nameAddress[2];
            string town = nameAddress[3];

            if (nameAddress.Length == 5)
            {
                town = $"{nameAddress[3]} {nameAddress[4]}";
            }

            Threeuple<string, string, string> nameWithAddress = new(name, address, town);

            Console.WriteLine(nameWithAddress.ToString());


            string[] nameBeer = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            name = nameBeer[0];
            int litersOfBeer = int.Parse(nameBeer[1]);
            bool isDrunk;
            if (nameBeer[2] == "drunk")
            {
                isDrunk = true;
            }
            else
            {
                isDrunk = false;
            }

            Threeuple<string, int, bool> nameWithBeer = new(name, litersOfBeer, isDrunk);

            Console.WriteLine(nameWithBeer.ToString());


            string[] nameBank = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            name = nameBank[0];
            double accountBalance = double.Parse(nameBank[1]);
            string bankName = nameBank[2];

            Threeuple<string, double, string> intWIthDouble = new(name, accountBalance, bankName);

            Console.WriteLine(intWIthDouble.ToString());
        }
    }
}
