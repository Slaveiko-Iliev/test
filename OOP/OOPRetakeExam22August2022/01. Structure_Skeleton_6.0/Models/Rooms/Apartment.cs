namespace BookingApp.Models.Rooms
{
    public class Apartment : Room
    {
        private const int _BedCapacity = 6;

        public Apartment() : base(_BedCapacity)
        {
        }
    }
}
