using System;

namespace _07.MaxSequenceOfEqualElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();

            int count = 0;
            int currentCount = 0;
            int currentFirstOfEqualElements = 0;
            int firstOfEqualElements = 0;

            for (int i = 0; i < array.Length; i++)
            {
               
                if (i + 1 < array.Length && array[i] == array[i+1] && currentCount == 0)
                {
                    currentFirstOfEqualElements = i;
                    currentCount++;
                }
                else if (i + 1 < array.Length && array[i] == array[i + 1])
                {
                    currentCount++;
                }
                else
                {
                    if (currentCount > count)
                    {
                        count = currentCount;
                        firstOfEqualElements = currentFirstOfEqualElements;
                        currentCount = 0;
                        currentFirstOfEqualElements = 0;
                    }
                    else
                    {
                        currentCount = 0;
                        currentFirstOfEqualElements = 0;
                    }
                }
            }
            string[]equalArray = new string[count + 1];
            for (int i = 0; i < count + 1; i++)
            {
               equalArray[i] = array [firstOfEqualElements]; 
            }
            Console.WriteLine(string.Join(' ', equalArray));
        }
    }
}
