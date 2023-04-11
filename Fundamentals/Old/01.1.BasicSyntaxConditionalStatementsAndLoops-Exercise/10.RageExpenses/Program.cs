using System;
using System.Diagnostics;

namespace _10.RageExpenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int brokenHeadsetCount = (lostGamesCount / 2);
            int brokenMouseCount = (lostGamesCount / 3);
            int brokenKeyboardCount = (lostGamesCount / 6);
            int brokenDisplayCount = (lostGamesCount / 12);

            

            double expenses = brokenHeadsetCount * headsetPrice + brokenMouseCount * mousePrice + brokenKeyboardCount * keyboardPrice + brokenDisplayCount * displayPrice;

            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}
