using System;

namespace BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());
            int countOfLectures = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());
            double maxBonus = 0;
            int maxAttendance = 0;

            for (int i = 0; i < countOfStudents; i++)
            {
                int attendance = int.Parse(Console.ReadLine());

                double totalBonus = ((1.0 * attendance / countOfLectures) * (5 + additionalBonus));

                if (maxBonus < totalBonus)
                {
                    maxBonus = totalBonus;
                    maxAttendance = attendance;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {maxAttendance} lectures.");
        }
    }
}