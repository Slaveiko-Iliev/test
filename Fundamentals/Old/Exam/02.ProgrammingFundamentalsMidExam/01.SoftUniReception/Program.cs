using System;

namespace _01.SoftUniReception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstEmployee = int.Parse(Console.ReadLine());
            var secondEmployee = int.Parse(Console.ReadLine());
            var thirdEmployee = int.Parse(Console.ReadLine());
            var studentCount = int.Parse(Console.ReadLine());

            var timeNeded = 0;
            var restTime = 0;
            var allEmployee = firstEmployee + secondEmployee + thirdEmployee;

            while (studentCount > 0)
            {
                if (timeNeded > 0 && timeNeded % 3  == 0)
                {
                    restTime++;
                }
                
                studentCount -= allEmployee;
                timeNeded++;
            }

            var totalTime = timeNeded + restTime;

            Console.WriteLine($"Time needed: {totalTime}h.");
        }
    }
}
