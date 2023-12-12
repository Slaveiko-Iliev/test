using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> _rooms;

        public RoomRepository()
        {
            _rooms = new List<IRoom>();
        }

        public void AddNew(IRoom model) => _rooms.Add(model);

        public IReadOnlyCollection<IRoom> All() => _rooms.AsReadOnly();

        // ???
        public IRoom Select(string criteria) => _rooms.Where(r => r.GetType().Name == criteria) as IRoom;
    }
}
