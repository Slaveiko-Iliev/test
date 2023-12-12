using BookingApp.Models.Rooms.Contracts;
using System;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private double _pricePerNight;

        protected Room(int bedCapacity)
        {
            BedCapacity = bedCapacity;
            PricePerNight = 0;
        }

        public int BedCapacity { get; private set; }

        public double PricePerNight
        {
            get => _pricePerNight;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative!");
                }
                _pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            PricePerNight = price;
        }
    }
}
