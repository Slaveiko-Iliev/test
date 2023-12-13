using System;
using System.Collections.Generic;
using System.Linq;
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

            IStudent currentStudent = new Student(students.Models.Count, firstName, lastName);

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
            List<int> requiredSubjectsAsInt = requiredSubjects.Select(int.Parse).ToList();

            IUniversity currentUniversity = new University(universityId, universityName, category, capacity, requiredSubjectsAsInt);

            universities.AddModel(currentUniversity);

            return $"{universityName} university is created and added to the {universities.GetType().Name}!";
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            throw new NotImplementedException();
        }

        public string TakeExam(int studentId, int subjectId)
        {
            throw new NotImplementedException();
        }

        public string UniversityReport(int universityId)
        {
            throw new NotImplementedException();
        }
    }
}
