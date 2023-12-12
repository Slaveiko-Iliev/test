using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> _bookings;

        public BookingRepository()
        {
            _bookings = new List<IBooking>();
        }

        public void AddNew(IBooking model) => _bookings.Add(model);

        public IReadOnlyCollection<IBooking> All() => _bookings.AsReadOnly();

        public IBooking Select(string criteria) => _bookings.FirstOrDefault(b => b.BookingNumber == int.Parse(criteria)) as IBooking;
    }
}
