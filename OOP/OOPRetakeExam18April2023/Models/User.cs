using EDriveRent.Models.Contracts;
using System;

namespace EDriveRent.Models
{
    public class User : IUser
    {
        private string _firstName;
        private string _lastName;
        private string _drivingLicenseNumber;
        private double _rating;
        private bool _isBlocked;

        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            _rating = 0;
            DrivingLicenseNumber = drivingLicenseNumber;
            _isBlocked = false;
        }

        public string FirstName
        {
            get => _firstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("FirstName cannot be null or whitespace!");
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
                    throw new ArgumentException("LastName cannot be null or whitespace!");
                }

                _lastName = value;
            }
        }

        public double Rating => _rating;

        public string DrivingLicenseNumber
        {
            get => _drivingLicenseNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Driving license number is required!");
                }

                _drivingLicenseNumber = value;
            }
        }

        public bool IsBlocked => _isBlocked;

        public void DecreaseRating()
        {
            _rating -= 2.0;
            if (_rating < 0)
            {
                _rating = 0;
                _isBlocked = true;
            }
        }

        public void IncreaseRating()
        {
            _rating += 0.5;
            if (_rating > 10)
            {
                _rating = 10;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} Driving license: {DrivingLicenseNumber} Rating: {_rating}";
        }
    }
}
