﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SoftUniParking
{
    public class Car
    {
        private string make;
        private string model;
        private int horsePower;
        private string registrationNumber;

        public Car()
        {
            Make = make;
            Model = model;
            HoursePower = horsePower;
            RegistrationNumber = registrationNumber;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public int HoursePower { get; set; }
        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            return $"Make: {make}{Environment.NewLine}" +
                $"Model: {model}{Environment.NewLine}" +
                $"HorsePower: {horsePower}{Environment.NewLine}" +
                $"RegistrationNumber: {registrationNumber}";
        }
    }
}