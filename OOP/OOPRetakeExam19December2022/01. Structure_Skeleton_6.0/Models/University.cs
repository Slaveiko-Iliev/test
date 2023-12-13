using System;
using System.Collections.Generic;
using UniversityCompetition.Models.Contracts;

namespace UniversityCompetition.Models
{
    public class University : IUniversity
    {
        private string _name;
        private string _category;
        private int _capacity;
        private List<int> _requiredSubjects;

        public University(int universityId, string universityName, string category, int capacity, List<int> requiredSubjects)
        {
            Id = universityId;
            Name = universityName;
            Category = category;
            Capacity = capacity;
            _requiredSubjects = requiredSubjects;
        }

        public int Id { get; private set; }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                _name = value;
            }
        }

        public string Category
        {
            get => _category;
            private set
            {
                if (value != "Technical" && value != "Economical" && value != "Humanity")
                {
                    throw new ArgumentException($"University category {value} is not allowed in the application!");
                }
                _category = value;
            }
        }

        public int Capacity
        {
            get => _capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("University capacity cannot be a negative value!");
                }
                _capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects => _requiredSubjects;
    }
}
