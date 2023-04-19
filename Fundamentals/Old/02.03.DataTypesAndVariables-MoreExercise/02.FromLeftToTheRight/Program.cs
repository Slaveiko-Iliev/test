using System;

namespace _02.FromLeftToTheRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
             
            for (int i = 0; i < N; i++)
            {
                string text = Console.ReadLine();
                string strNum = string.Empty, strNum1 = string.Empty, strNum2 = string.Empty;
                int num = 0, num1 = 0, num2 = 0, intC = 0;

                for (int j = 0; j < text.Length; j++)
                {
                    char c = text[j];
                    if (c != ' ' && c != '-')
                    {
                        intC = (int)c - 48;
                        strNum += c;
                        num += intC;
                    }
                    
                    else if (c ==' ')
                    {
                        strNum1 = strNum;
                        strNum = string.Empty;
                        num1 = num;
                        num = 0;
                    }
                    else if (c == '-')
                    {
                        strNum += c;
                    }
                }
                strNum2 = strNum;
                num2 = num;
                long number1 = long.Parse(strNum1);
                long number2 = long.Parse(strNum2);
                if (number1 >= number2)
                {
                    Console.WriteLine(num1);
                }
                else
                {
                    Console.WriteLine(num2);
                }
                
            }
        }
    }
}
