using System;

namespace _09.PadawanEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double johnsMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLightsabers = double.Parse(Console.ReadLine());
            double priceOfRobe = double.Parse(Console.ReadLine());
            double priceOfBelt = double.Parse(Console.ReadLine());

            //Lightsabres sometimes break, so John should buy 10 % more(taken from the students' count), rounded up to the next integer.
            //Every sixth belt is free.

            int beltDiscount = countOfStudents / 6;

            double total = priceOfLightsabers * (Math.Ceiling(countOfStudents * 1.1)) + priceOfRobe * countOfStudents + priceOfBelt * (countOfStudents - beltDiscount);

            if (johnsMoney >= total)
            {
                Console.WriteLine($"The money is enough - it would cost {total:f2}lv.");
            }
            else if (johnsMoney < total)
            {
                Console.WriteLine($"John will need {total - johnsMoney:f2}lv more.");
            }
        }
    }
}
