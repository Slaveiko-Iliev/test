using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> _hotels;

        public HotelRepository()
        {
            _hotels = new List<IHotel>();
        }

        public void AddNew(IHotel model) => _hotels.Add(model);

        public IReadOnlyCollection<IHotel> All() => _hotels.AsReadOnly();

        public IHotel Select(string criteria) => _hotels.FirstOrDefault(h => h.FullName == criteria);
    }
}
