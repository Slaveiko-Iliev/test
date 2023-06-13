using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BonusScoringSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            int numberOfLectures = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            List<int> attendanceOfStudents = new List<int>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                int currentStudentAttendance = int.Parse(Console.ReadLine());

                attendanceOfStudents.Add(currentStudentAttendance);
            }

            int maxStudentAttendance = 0;
            double totalBonus = 0;

            if (numberOfStudents > 0)
            {
                maxStudentAttendance = attendanceOfStudents.Max();
                totalBonus = (double)maxStudentAttendance / numberOfLectures * (5 + additionalBonus);
            }

            

            Console.WriteLine($"Max Bonus: {Math.Ceiling(totalBonus)}.");
            Console.WriteLine($"The student has attended {maxStudentAttendance} lectures.");
        }
    }
}
