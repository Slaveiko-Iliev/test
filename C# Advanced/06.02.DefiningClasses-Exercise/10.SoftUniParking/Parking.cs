using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new Dictionary<string, Car>();
        }

        private int myVar;

        public int Count
        {
            get { return cars.Count; }
        }


        public string AddCar(Car car)
        {
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (cars.Count == capacity)
            {
                return "Parking is full!";
            }
            else
            {
                cars.Add(car.RegistrationNumber, car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return cars[registrationNumber];
        }

        public string RemoveCar(string registrationNumber)
        {
            bool isRemoved = cars.Remove(registrationNumber);

            if (isRemoved)
            {
                return $"Successfully removed {registrationNumber}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (string registrationNumber in RegistrationNumbers)
            {
                if (cars.ContainsKey(registrationNumber))
                {
                    cars.Remove(registrationNumber);
                }
            }
        }
    }

    
}
