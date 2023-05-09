using System;

namespace _03.Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int numberA = int.Parse(Console.ReadLine());
            int numberb = int.Parse(Console.ReadLine());

            switch (command)
            {
                case "add":
                    AddNum(numberA, numberb);
                    break;
                case "multiply":
                     MultiplyNum (numberA, numberb);
                    break;
                case "subtract":
                    SubtractNum (numberA, numberb);
                    break;
                case "divide":
                    DivideNum (numberA, numberb);
                    break;
            }
        }

        private static void DivideNum(int numberA, int numberb)
        {
            int result = numberA / numberb;
            Console.WriteLine(result);
        }

        private static void SubtractNum(int numberA, int numberb)
        {
            Console.WriteLine(numberA - numberb);
        }

        private static void MultiplyNum(int numberA, int numberb)
        {
            Console.WriteLine(numberA * numberb);
        }

        private static void AddNum(int numberA, int numberb)
        {
            Console.WriteLine(numberA + numberb);
        }
    }
}
