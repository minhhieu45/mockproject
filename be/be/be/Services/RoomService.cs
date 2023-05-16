using be.Models;

namespace be.Services
{
    public class RoomService : IRoomService
    {
        private readonly DbFourSeasonHotelContext _context;

        public RoomService()
        {
            _context = new DbFourSeasonHotelContext();
        }

        public void AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public void DeleteRoom(int roomId)
        {
            var item = _context.Rooms.Find(roomId);
            _context.Rooms.Remove(item);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IList<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }

        public Room GetRoom(int roomId)
        {
            return _context.Rooms.Find(roomId);
        }

        public void UpdateRoom(Room room)
        {
            Room updateRoom = _context.Rooms.Find(room.RoomId);
            updateRoom = room;
            _context.SaveChanges();
        }
    }
}
