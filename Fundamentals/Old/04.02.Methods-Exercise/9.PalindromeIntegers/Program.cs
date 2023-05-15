using System;

namespace _9.PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            
            while ((input = Console.ReadLine()) != "END")
            {
                bool isPalindrome = false;

                string current = string.Empty;

                for (int i = input.Length - 1; i >= 0; i--)
                {
                    if (char.IsDigit(input[i]))
                    {
                        current += input[i];
                    }
                }

                if (input == current)
                {
                    isPalindrome = true;
                }

                if (isPalindrome)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        } 
    }
}
