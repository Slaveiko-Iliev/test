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
                    .FirstOrDefault(r => r.BedCapacity == adults + children);

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
            var currentHotel = hotels.All().Where(h => h.FullName == hotelName);

            if (currentHotel == null)
            {
                return $"Profile {hotelName} doesn't exist!";
            }


        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (!hotels.All().Any(ho => ho.FullName == hotelName))
            {
                return $"Profile {hotelName} doesn’t exist!";
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

            if (!hotels.All().First(ho => ho.FullName == hotelName).Rooms.All().Any(r => r.GetType().Name == roomTypeName))
            {
                return $"Room type is not created yet!";
            }

            if (hotels.All().First(ho => ho.FullName == hotelName).Rooms.All().First(r => r.GetType().Name == roomTypeName).PricePerNight != 0)
            {
                return $"Price is already set!";
            }

            hotels.All().First(ho => ho.FullName == hotelName).Rooms.All().First(r => r.GetType().Name == roomTypeName).SetPrice(price);

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
