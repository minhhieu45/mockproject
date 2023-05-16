using be.Models;

namespace be.Services
{
    public interface IUserService : IDisposable
    {
        User GetUser(int userId);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        IList<User> GetAllUsers();
    }
}
