namespace _05.BirthdayCelebrations
{
    public interface IBuyer : INameable
    {
        public int Food {  get; set; }

        public void BuyFood();
    }
}
