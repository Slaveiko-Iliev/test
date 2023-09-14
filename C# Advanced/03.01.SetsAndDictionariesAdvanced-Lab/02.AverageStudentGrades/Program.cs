using System;
using System.Collections.Generic;
using System.Linq;

int countOfStudents = int.Parse(Console.ReadLine());

Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

for (int student = 0; student < countOfStudents; student++)
{
    string[] studentInfo = Console.ReadLine()
        .Split(' ');

    string studentName = studentInfo[0];
    decimal studentGrade = decimal.Parse(studentInfo[1]);

    if (!students.ContainsKey(studentName))
    {
        students.Add(studentName, new List<decimal>());
    }

    students[studentName].Add(studentGrade);
}

foreach (var (student, grades) in students)
{
    Console.Write($"{student} -> ");

    foreach (var grade in grades)
    {
        Console.Write($"{grade:f2} ");
    }

    Console.WriteLine($"(avg: {grades.Average():f2})");
}