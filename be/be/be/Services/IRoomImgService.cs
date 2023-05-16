using be.Models;

namespace be.Services
{
    public interface IRoomImgService : IDisposable
    {
        void AddRoomImg(IList<string> imgs, int roomId);
        void DeleteRoomImg(IList<string> imgs, int roomId);
        IList<RoomImg> GetAllRoomImg(int roomId);
    }
}
