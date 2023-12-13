using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        SubjectRepository subjects;
        StudentRepository students;
        UniversityRepository universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {
            if (students.Models.Any(st => st.FirstName == firstName && st.LastName == lastName))
            {
                return $"{firstName} {lastName} is already added in the repository.";
            }

            IStudent currentStudent = new Student(students.Models.Count + 1, firstName, lastName);

            students.AddModel(currentStudent);

            return $"Student {firstName} {lastName} is added to the {students.GetType().Name}!";
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType != "EconomicalSubject" && subjectType != "HumanitySubject" && subjectType != "TechnicalSubject")
            {
                return $"Subject type {subjectType} is not available in the application!";
            }

            if (subjects.Models.Any(sub => sub.Name == subjectName))
            {
                return $"{subjectName} is already added in the repository.";
            }

            ISubject currentSubject = new EconomicalSubject(subjects.Models.Count + 1, subjectName);

            if (subjectType == "HumanitySubject")
            {
                currentSubject = new EconomicalSubject(subjects.Models.Count + 1, subjectName);
            }
            else if (subjectType == "TechnicalSubject")
            {
                currentSubject = new TechnicalSubject(subjects.Models.Count + 1, subjectName);
            }

            subjects.AddModel(currentSubject);

            return $"{subjectType} {subjectName} is created and added to the {subjects.GetType().Name}!";
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universities.Models.Any(uni => uni.Name == universityName))
            {
                return $"{universityName} is already added in the repository.";
            }

            int universityId = universities.Models.Count + 1;
            List<int> requiredSubjectsAsInt = new();

            foreach (var subjectName in requiredSubjects)
            {
                requiredSubjectsAsInt.Add(subjects.FindByName(subjectName).Id);
            }

            IUniversity currentUniversity = new University(universityId, universityName, category, capacity, requiredSubjectsAsInt);

            universities.AddModel(currentUniversity);

            return $"{universityName} university is created and added to the {universities.GetType().Name}!";
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] studentFullName = studentName.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string studentFirstName = studentFullName[0];
            string studentLastName = studentFullName[1];

            if (!students.Models.Any(stu => stu.FirstName == studentFirstName && stu.LastName == studentLastName))
            {
                return $"{studentFirstName} {studentLastName} is not registered in the application!";
            }

            if (!universities.Models.Any(uni => uni.Name == universityName))
            {
                return $"{universityName} is not registered in the application!";
            }

            bool isCovered = true;
            IUniversity currentUniversity = universities.FindByName(universityName);
            IStudent currentStudent = students.Models.First(stu => stu.FirstName == studentFirstName && stu.LastName == studentLastName);

            foreach (var exam in currentUniversity.RequiredSubjects)
            {
                if (!currentStudent.CoveredExams.Contains(exam))
                {
                    isCovered = false;
                }
            }

            if (!isCovered)
            {
                return $"{studentName} has not covered all the required exams for {universityName} university!";
            }

            if (currentStudent.University == currentUniversity)
            {
                return $"{studentFirstName} {studentLastName} has already joined {currentUniversity.Name}.";
            }

            currentStudent.JoinUniversity(currentUniversity);

            return $"{studentFirstName} {studentLastName} joined {universityName} university!";
        }

        public string TakeExam(int studentId, int subjectId)
        {
            if (!students.Models.Any(stu => stu.Id == studentId))
            {
                return "Invalid student ID!";
            }

            if (!subjects.Models.Any(obj => obj.Id == subjectId))
            {
                return "Invalid subject ID!";
            }

            IStudent currentStudent = students.Models.First(stu => stu.Id == studentId);
            ISubject currentSubject = subjects.Models.First(obj => obj.Id == subjectId);

            if (currentStudent.CoveredExams.Contains(subjectId))
            {
                return $"{currentStudent.FirstName} {currentStudent.LastName} has already covered exam of {currentSubject.Name}.";
            }

            currentStudent.CoverExam(currentSubject);

            return $"{currentStudent.FirstName} {currentStudent.LastName} covered {currentSubject.Name} exam!";
        }

        public string UniversityReport(int universityId)
        {
            IUniversity currentUniversity = universities.FindById(universityId);

            StringBuilder sb = new();

            sb.AppendLine($"*** {currentUniversity.Name} ***");
            sb.AppendLine($"Profile: {currentUniversity.Category}");
            sb.AppendLine($"Students admitted: {students.Models.Where(st => st.University == currentUniversity).Count()}");
            sb.AppendLine($"University vacancy: {currentUniversity.Capacity - students.Models.Where(st => st.University == currentUniversity).Count()}");

            return sb.ToString().TrimEnd();
        }
    }
}
