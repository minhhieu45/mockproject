using be.Models;

namespace be.Services
{
    public class RoomImgService : IRoomImgService
    {
        private readonly DbFourSeasonHotelContext _context;

        public RoomImgService()
        {
            _context = new DbFourSeasonHotelContext();
        }

        public void AddRoomImg(IList<string> imgs, int roomId)
        {
            throw new NotImplementedException();
        }

        public void DeleteRoomImg(IList<string> imgs, int roomId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IList<RoomImg> GetAllRoomImg(int roomId)
        {
            throw new NotImplementedException();
        }
    }
}
