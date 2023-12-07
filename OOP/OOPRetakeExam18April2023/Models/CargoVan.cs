namespace EDriveRent.Models
{
    public class CargoVan : Vehicle
    {
        public const double _MaxMileage = 180;

        public CargoVan(string brand, string model, string licensePlateNumber) : base(brand, model, _MaxMileage, licensePlateNumber)
        {
        }

        //public override void Drive(double mileage)
        //{
        //    this.BatteryLevel = (int)(100 - Math.Round(mileage / _MaxMileage * 100, 0) - 5);
        //}
    }
}
