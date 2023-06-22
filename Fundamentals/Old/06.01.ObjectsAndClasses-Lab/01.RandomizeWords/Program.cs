using System;

namespace _01.RandomizeWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arrayOfWords = Console.ReadLine().Split(' ');

            for (int i = 0; i < arrayOfWords.Length; i++)
            {
                Random random = new Random();
                int randomIndex = random.Next(0, arrayOfWords.Length);

                string CurrentWord = arrayOfWords[i];
                string wordToSwap = arrayOfWords[randomIndex];

                arrayOfWords[i] = wordToSwap;
                arrayOfWords[randomIndex] = CurrentWord;
            }
            Console.WriteLine(string.Join(Environment.NewLine, arrayOfWords));
        }
    }
}
