namespace ChristmasPastryShop.Models.Delicacies
{
    public class Gingerbread : Delicacy
    {
        private const double Price = 4.00;

        public Gingerbread(string delicacyName) : base(delicacyName, Price)
        {
        }
    }
}
