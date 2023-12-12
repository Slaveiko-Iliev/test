using BookingApp.Core.Contracts;
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
            throw new NotImplementedException();
        }

        public string HotelReport(string hotelName)
        {
            throw new NotImplementedException();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            throw new NotImplementedException();
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
