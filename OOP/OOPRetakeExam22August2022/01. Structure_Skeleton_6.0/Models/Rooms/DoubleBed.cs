namespace BookingApp.Models.Rooms
{
    public class DoubleBed : Room
    {

        private const int _BedCapacity = 2;

        public DoubleBed() : base(_BedCapacity)
        {
        }
    }
}
