using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using System;
using System.Text;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private int _residenceDuration;
        private int _adultsCount;
        private int _childrenCount;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            BookingNumber = bookingNumber;
        }

        public IRoom Room { get; private set; }

        public int ResidenceDuration
        {
            get => _residenceDuration;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Duration cannot be negative or zero!");
                }
                _residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get => _adultsCount;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Adults count cannot be negative or zero!");
                }
                _adultsCount = value;
            }
        }

        public int ChildrenCount
        {
            get => _childrenCount;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Children count cannot be negative!");
                }
                _childrenCount = value;
            }
        }

        public int BookingNumber { get; private set; }

        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder();

            var totalPaid = Math.Round(ResidenceDuration * Room.PricePerNight, 2);

            sb.AppendLine($"Booking number: {BookingNumber}");
            sb.AppendLine($"Room type: {Room.GetType().Name}");
            sb.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
            sb.AppendLine($"Total amount paid: {totalPaid:F2} $");

            return sb.ToString().TrimEnd();
        }
    }
}
