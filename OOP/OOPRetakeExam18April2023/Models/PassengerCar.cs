namespace EDriveRent.Models
{
    public class PassengerCar : Vehicle
    {
        public const double _MaxMileage = 450;


        public PassengerCar(string brand, string model, string licensePlateNumber) : base(brand, model, _MaxMileage, licensePlateNumber)
        {
        }
    }
}
