namespace BookingApp.Models.Rooms
{
    public class Studio : Room
    {
        private const int _BedCapacity = 4;


        public Studio() : base(_BedCapacity)
        {
        }
    }
}
