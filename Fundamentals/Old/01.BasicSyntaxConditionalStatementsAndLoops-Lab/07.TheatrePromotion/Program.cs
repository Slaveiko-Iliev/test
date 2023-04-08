using System;

namespace _07.TheatrePromotion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Day / Age   0 <= age <= 18  18 < age <= 64  64 < age <= 122
            //Weekday         12$	            18$	            12$
            //Weekend         15$	            20$         	15$
            //Holiday         5$	            12$	            10$

            string typeOfDay = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            if (typeOfDay == "Weekday" && age >= 0 && age <= 18) Console.WriteLine("12$");
            else if (typeOfDay == "Weekday" && age > 18 && age <= 64) Console.WriteLine("18$");
            else if (typeOfDay == "Weekday" && age > 64 && age <= 122) Console.WriteLine("12$");
            else if (typeOfDay == "Weekend" && age >= 0 && age <= 18) Console.WriteLine("15$");
            else if (typeOfDay == "Weekend" && age > 18 && age <= 64) Console.WriteLine("20$");
            else if (typeOfDay == "Weekend" && age > 64 && age <= 122) Console.WriteLine("15$");
            else if (typeOfDay == "Holiday" && age >= 0 && age <= 18) Console.WriteLine("5$");
            else if (typeOfDay == "Holiday" && age > 18 && age <= 64) Console.WriteLine("12$");
            else if (typeOfDay == "Holiday" && age > 64 && age <= 122) Console.WriteLine("10$");
            else Console.WriteLine("Error!");
        }
    }
}
