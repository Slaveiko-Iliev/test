namespace CarManufacturer
{
    class Car
    {
        //----------------- Fields -----------------
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        //-------------- Constructors --------------
        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }
        //--------------- Properties ---------------
        public string Make
        {
            get { return this.make; }
            private set { this.make = value; }
        }

        public string Model
        {
            get { return this.model; }
            private set { this.model = value; }
        }

        public int Year
        {
            get { return this.year; }
            private set { this.year = value; }
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            private set { this.fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            private set { this.fuelConsumption = value; }
        }

        public Engine Engine
        {
            get { return this.engine; }
            private set { this.engine = value; }
        }

        public Tire[] Tires
        {
            get { return this.tires; }
            private set { this.tires = value; }
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace CarManufacturer
//{
//    public class Car
//    {
//        public Car()
//        {
//            Make = make;
//            Model = model;
//            Year = year;
//            FuelQuantity = fuelQuantity;
//            FuelConsumption = fuelConsumption;
//        }

//        public Car(string make, string model, int year) : this()
//        {
//            Make = make;
//            Model = model;
//            Year = year;
//        }

//        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
//        {
//            FuelQuantity = fuelQuantity;
//            FuelConsumption = fuelConsumption;
//        }

//        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires) : this(make, model, year, fuelQuantity, fuelConsumption)
//        {
//            Engine = engine;
//            Tires = tires;
//        }


//        private string make = "VW";
//        private string model = "Golf";
//        private int year = 2025;
//        private double fuelQuantity = 200;
//        private double fuelConsumption = 10; //Engine and Tire[].
//        private Engine engine;
//        private Tire[] tires;

//        public string Model
//        {
//            get { return model; }
//            set { model = value; }
//        }
//        public string Make
//        {
//            get { return make; }
//            set { make = value; }
//        }
//        public int Year
//        {
//            get { return year; }
//            set { year = value; }
//        }
//        public double FuelQuantity
//        {
//            get { return fuelQuantity; }
//            set { fuelQuantity = value; }
//        }
//        public double FuelConsumption
//        {
//            get { return fuelConsumption; }
//            set { fuelConsumption = value; }
//        }

//        public Engine Engine { get; set; }

//        public Tire[] Tires
//        {
//            get { return this.tires; }
//            private set { this.tires = value; }
//        }



//        public void Drive(double distance)
//        {
//            if (fuelQuantity >= distance * fuelConsumption)
//            {
//                fuelQuantity -= distance * fuelConsumption;
//            }
//            else
//            {
//                Console.WriteLine("Not enough fuel to perform this trip!");
//            }
//        }

//        public string WhoAmI()
//        {
//            return $"Make: {this.Make}{Environment.NewLine}Model: {this.Model}{Environment.NewLine}Year: {this.Year}{Environment.NewLine}Fuel: {this.FuelQuantity:F2}";
//        }
//    }

//}
