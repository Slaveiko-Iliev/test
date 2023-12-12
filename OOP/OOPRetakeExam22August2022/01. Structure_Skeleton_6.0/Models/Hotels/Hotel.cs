using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using System;
using System.Linq;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string _fullName;
        private int _category;

        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
            Rooms = new RoomRepository();
            Bookings = new BookingRepository();
        }

        public string FullName
        {
            get => _fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hotel name cannot be null or empty!");
                }
                _fullName = value;
            }
        }

        public int Category
        {
            get => _category;
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Category should be between 1 and 5 stars!");
                }
                _category = value;
            }
        }

        public double Turnover => Bookings.All().Select(b => b.ResidenceDuration * b.Room.PricePerNight).Sum();

        public IRepository<IRoom> Rooms { get; private set; }

        public IRepository<IBooking> Bookings { get; private set; }
    }
}
