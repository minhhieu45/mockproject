using be.Models;

namespace be.Services
{
    public interface IRoomService : IDisposable
    {
        Room GetRoom(int roomId);
        void AddRoom(Room room);
        void UpdateRoom(Room room);
        void DeleteRoom(int roomId);
        IList<Room> GetAllRooms();
    }
}
