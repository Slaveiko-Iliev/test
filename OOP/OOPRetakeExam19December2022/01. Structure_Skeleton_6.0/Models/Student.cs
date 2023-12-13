using System;
using System.Collections.Generic;
using UniversityCompetition.Models.Contracts;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {
        private string _firstName;
        private string _lastName;
        private List<int> _coveredExams;

        public Student(int studentId, string firstName, string lastName)
        {
            Id = studentId;
            FirstName = firstName;
            LastName = lastName;
            _coveredExams = new();
        }

        public int Id { get; private set; }

        public string FirstName
        {
            get => _firstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                _lastName = value;
            }
        }

        public IReadOnlyCollection<int> CoveredExams => _coveredExams;

        public IUniversity University { get; private set; }

        public void CoverExam(ISubject subject) => _coveredExams.Add(subject.Id);

        public void JoinUniversity(IUniversity university) => University = university;
    }
}
