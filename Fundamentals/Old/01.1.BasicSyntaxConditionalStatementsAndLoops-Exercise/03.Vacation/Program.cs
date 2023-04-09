using System;

namespace _03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //           Friday Saturday    Sunday
            //Students    8.45    9.80    10.46
            //Business    10.90   15.60   16
            //Regular     15      20      22.50

            int countOfPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double price = 0;

            if (typeOfGroup == "Students" && dayOfWeek == "Friday")
            {
                price = 8.45;
            }
            else if (typeOfGroup == "Students" && dayOfWeek == "Saturday")
            {
                price = 9.8;
            }
            else if (typeOfGroup == "Students" && dayOfWeek == "Sunday")
            {
                price = 10.46;
            }
             else if (typeOfGroup == "Business" && dayOfWeek == "Friday")
            {
                price = 10.9;
            }
            else if (typeOfGroup == "Business" && dayOfWeek == "Saturday")
            {
                price = 15.6;
            }
            else if (typeOfGroup == "Business" && dayOfWeek == "Sunday")
            {
                price = 16;
            }
            else if (typeOfGroup == "Regular" && dayOfWeek == "Friday")
            {
                price = 15;
            }
            else if (typeOfGroup == "Regular" && dayOfWeek == "Saturday")
            {
                price = 20;
            }
            else if (typeOfGroup == "Regular" && dayOfWeek == "Sunday")
            {
                price = 22.5;
            }

            if (typeOfGroup == "Students" && countOfPeople >= 30)
            {
                price *= 0.85;
            }
            else if (typeOfGroup == "Business" && countOfPeople >= 100)
            {
                countOfPeople -= 10;
            }
            else if (typeOfGroup == "Regular" && countOfPeople >= 10 && countOfPeople <= 20)
            {
                price *= 0.95;
            }

            double totalPrice = countOfPeople * price;

            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
