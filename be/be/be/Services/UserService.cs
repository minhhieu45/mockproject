using be.Models;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace be.Services
{
    public class UserService : IUserService
    {
        private readonly DbFourSeasonHotelContext _context;

        public UserService()
        {
            _context = new DbFourSeasonHotelContext();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var item = _context.Users.Find(userId);
            _context.Users.Remove(item);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IList<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUser(int userId)
        {
            return _context.Users.Find(userId);
        }

        public void UpdateUser(User user)
        {
            User updateUser = _context.Users.Find(user.UserId);
            updateUser = user;
            _context.SaveChanges();
        }
        public string CreateToken(string email, int? id, IConfiguration config)
        {
            string role = _context.Roles.Find(id).RoleName;
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                config.GetSection("AppSettings:Token").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return "bearer " + jwt;
        }
    }
}
