using EDriveRent.Models.Contracts;
using System;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string _brand;
        private string _model;
        private string _licensePlateNumber;

        protected Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            MaxMileage = maxMileage;
            LicensePlateNumber = licensePlateNumber;
            BatteryLevel = 100;
            IsDamaged = false;
        }

        public string Brand
        {
            get => _brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Brand cannot be null or whitespace!");
                }
                _brand = value;
            }
        }

        public string Model
        {
            get => _model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model cannot be null or whitespace!");
                }
                _model = value;
            }
        }

        public double MaxMileage { get; private set; }

        public string LicensePlateNumber
        {
            get => _licensePlateNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("License plate number is required!");
                }
                _licensePlateNumber = value;
            }
        }

        public int BatteryLevel { get; private set; }

        public bool IsDamaged { get; private set; }

        public void ChangeStatus()
        {
            if (IsDamaged)
            {
                IsDamaged = false;
            }
            else
            {
                IsDamaged = true;
            }
        }

        public void Drive(double mileage)
        {
            this.BatteryLevel = (int)(100 - Math.Round(mileage / MaxMileage * 100, 0));

            if (this.GetType().Name == "CargoVan")
            {
                this.BatteryLevel -= 5;
            }
        }

        public void Recharge()
        {
            BatteryLevel = 100;
        }

        public override string ToString()
        {
            string status = string.Empty;
            if (IsDamaged)
            {
                status = "damaged";
            }
            else
            {
                status = "OK";
            }

            return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {status}";
        }
    }
}
