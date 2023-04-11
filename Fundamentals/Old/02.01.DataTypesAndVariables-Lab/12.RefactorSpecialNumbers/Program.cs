using System;

namespace _12.RefactorSpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            
            
            for (int ch = 1; ch <= n; ch++)
            {
                int currentNum = ch;
                int sumOfLastDifit = 0;
                while (currentNum > 0)
                {
                    sumOfLastDifit += currentNum % 10;
                    currentNum = currentNum / 10;
                }
                bool isspecialNum = (sumOfLastDifit == 5) || (sumOfLastDifit == 7) || (sumOfLastDifit == 11);
                Console.WriteLine("{0} -> {1}", ch, isspecialNum);
                
            }

        }
    }
}
