using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dictContestPassword = new Dictionary<string, string>();
            var dictNameStudent = new Dictionary<string, Student>();

            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] inputArray = input.Split(":");
                string contest = inputArray[0];
                string password = inputArray[1];
                if (!dictContestPassword.ContainsKey(contest))
                {
                    dictContestPassword.Add(contest, password);
                }
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] inputArray = input.Split("=>");
                string contest = inputArray[0];
                string password = inputArray[1];
                string studentName = inputArray[2];
                int points = int.Parse(inputArray[3]);

                if (!dictContestPassword.ContainsKey(contest) || dictContestPassword[contest] != password)
                {
                    continue;
                }

                if (!dictNameStudent.ContainsKey(studentName))
                {
                    dictNameStudent.Add(studentName, new Student(studentName));
                }

                Student student = dictNameStudent[studentName];

                if (!student.ContestsWithPoints.ContainsKey(contest))
                {
                    student.ContestsWithPoints.Add(contest, points);
                }

                if (student.ContestsWithPoints[contest] < points)
                {
                    student.ContestsWithPoints[contest] = points;
                }
            }

            PrintTheRanking(dictNameStudent.Values.ToList());
            ;
        }
        

        private class Student
        {
            public string Name { get; }
            public Dictionary<string, int> ContestsWithPoints { get; }

            public Student(string name)
            {
                Name = name;
                ContestsWithPoints = new Dictionary<string, int>();
            }
        }

        private static void PrintTheRanking(List<Student> listWithStudents)
        {
            var bestCandidate = listWithStudents.OrderByDescending(x => x.ContestsWithPoints.Values.Sum()).First();
            Console.WriteLine(
                $"Best candidate is {bestCandidate.Name} with total {bestCandidate.ContestsWithPoints.Values.Sum()} points.");
            Console.WriteLine("Ranking:");
            foreach (var student in listWithStudents.OrderBy(x => x.Name))
            {
                Console.WriteLine(student.Name);
                foreach (var (contest, points) in student.ContestsWithPoints.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }
    }
}
