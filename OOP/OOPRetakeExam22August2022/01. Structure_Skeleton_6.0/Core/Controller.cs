using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels;

        public Controller()
        {
            hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            if (hotels.All().Any(h => h.FullName == hotelName))
            {
                return $"Hotel {hotelName} is already registered in our platform.";
            }

            IHotel hotel = new Hotel(hotelName, category);
            hotels.AddNew(hotel);

            return $"{category} stars hotel {hotelName} is registered in our platform and expects room availability to be uploaded.";
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (!hotels.All().Any(h => h.Category == category))
            {
                return $"{category} star hotel is not available in our platform.";
            }

            var orderedHotels = hotels.All().Where(h => h.Category == category).OrderBy(h => h.FullName);

            foreach (var hotel in orderedHotels)
            {
                IRoom roomForBooking = hotel.Rooms.All()
                    .Where(r => r.PricePerNight > 0)
                    .Where(r => r.BedCapacity >= adults + children)
                    .OrderBy(r => r.BedCapacity)
                    .FirstOrDefault();

                if (roomForBooking != null)
                {
                    IBooking booking = new Booking(roomForBooking, duration, adults, children, hotel.Bookings.All().Count + 1);
                    hotel.Bookings.AddNew(booking);
                    return $"Booking number {hotel.Bookings.All().Count} for {hotel.FullName} hotel is successful!";
                }
            }

            return "We cannot offer appropriate room for your request.";
        }

        public string HotelReport(string hotelName)
        {
            var currentHotel = hotels.Select(hotelName);

            if (currentHotel == null)
            {
                return $"Profile {hotelName} doesn't exist!";
            }

            StringBuilder sb = new();

            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{currentHotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {currentHotel.Turnover:f2} $");
            sb.AppendLine("--Bookings:");
            sb.AppendLine();

            if (currentHotel.Bookings.All().Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                foreach (IBooking currentBooking in currentHotel.Bookings.All())
                {
                    sb.AppendLine(currentBooking.BookingSummary());
                    sb.AppendLine();
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (hotels.Select(hotelName) == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            if (roomTypeName != nameof(DoubleBed) && roomTypeName != nameof(Studio) && roomTypeName != nameof(Apartment))
            {
                throw new ArgumentException("Incorrect room type!");
            }

            IHotel currentHotel = hotels.Select(hotelName);

            if (currentHotel.Rooms.Select(roomTypeName) == null)
            {
                return $"Room type is not created yet!";
            }

            IRoom currentRoom = currentHotel.Rooms.Select(roomTypeName);

            if (currentRoom.PricePerNight > 0)
            {
                return $"Price is already set!";
            }

            currentRoom.SetPrice(price);

            return $"Price of {roomTypeName} room type in {hotelName} hotel is set!";
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (!hotels.All().Any(ho => ho.FullName == hotelName))
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            IHotel currentHotel = hotels.All().First(ho => ho.FullName == hotelName);

            if (currentHotel.Rooms.All().Any(r => r.GetType().Name == roomTypeName))
            {
                return $"Room type is already created!";
            }

            var subclassTypes = Assembly
                .GetAssembly(typeof(Room))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Room)));

            bool isValid = false;

            foreach (var room in subclassTypes)
            {
                if (room.Name == roomTypeName)
                {
                    isValid = true;
                    break;
                }
            }

            if (!isValid)
            {
                throw new ArgumentNullException("Incorrect room type!");
            }

            IRoom currentRoom = null;

            foreach (var room in subclassTypes)
            {
                if (room.Name == roomTypeName)
                {
                    currentRoom = Activator.CreateInstance(room) as IRoom;
                    break;
                }
            }

            currentHotel.Rooms.AddNew(currentRoom);

            return $"Successfully added {roomTypeName} room type in {hotelName} hotel!";
        }
    }
}
