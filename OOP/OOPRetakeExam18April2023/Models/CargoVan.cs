namespace EDriveRent.Models
{
    public class CargoVan : Vehicle
    {
        public const double _MaxMileage = 180;

        public CargoVan(string brand, string model, string licensePlateNumber) : base(brand, model, _MaxMileage, licensePlateNumber)
        {
        }
    }
}
