using System;

namespace _09.SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());

            int sumOfRealYield = 0;
            int countOfDays = 0;

            while (startingYield >= 100)
            {
                sumOfRealYield += startingYield;
                countOfDays++;
                startingYield -= 10;

                if (sumOfRealYield >= 26)
                {
                    sumOfRealYield -= 26;
                }
            }
            if (sumOfRealYield >= 26)
            {
                sumOfRealYield -= 26;
            }
            Console.WriteLine(countOfDays);
            Console.WriteLine(sumOfRealYield);
        }
    }
}
