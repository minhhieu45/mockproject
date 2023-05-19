using be.Controllers;
using be.Helpers;
using be.Models;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        public string CreateToken(string email, int id, IConfiguration config)
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
        public object Login(string email, string password, IConfiguration config)
        {
            string token = "";
            var user = _context.Users.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                return new
                {
                    status = 404,
                    message = "The account is not found"
                };
            }
            if (Helper.DecodeFrom64(user.Password) != password)
            {
                return new
                {
                    message = "Password is wrong",
                    status = 400
                };
            }
            if(user.Status == "0")
            {
                return new
                {
                    message = "Please check your email to confirm your account",
                    status = 400
                };
            }
            token = CreateToken(user.Email, (int)user.RoleId, config);
            return new
            {
                message = "Login success",
                status = 200,
                data = user,
                token
            };
        }
        public async Task<object> Register(User user)
        {
            if ((_context.Users?.Any(x => x.Email == user.Email)).GetValueOrDefault())
            {
                return new
                {
                    message = "Email is found",
                    status = 400
                };
            }
            user.Password = Helper.EncodePasswordToBase64(user.Password);
            if (user.RoleId == null)
            {
                var role = await _context.Roles.Where(x => x.RoleName == "Guest").FirstOrDefaultAsync();
                if (role != null)
                {
                    user.RoleId = role.RoleId;
                }
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            var id = (user.UserId).ToString();
            await EmailService.Instance.SendMail(user.Email, 2, id);
            return new
            {
                message = "Add account success!",
                status = 200,
            };
        }
        public async Task<object> ForgotPassword (string email)
        {
            var user = await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
            if(user == null)
            {
                return new
                {
                    status = 404,
                    message = "Email is not found"
                };
            }
            if(user.Status == "0")
            {
                return new
                {
                    status = 400,
                    message = "The account is unverified, please check email is verify."
                };
            }
            string _pass = RandomString.Instance.CreateString();
            string pass = Helper.EncodePasswordToBase64(_pass);
            user.Password = pass;
            await _context.SaveChangesAsync();
            var isCheck = await EmailService.Instance.SendMail(user.Email, 1, _pass);
            if(isCheck == false)
            {
                return new
                {
                    message = "Send a new password error!",
                    status = 400,
                };
            }
            return new
            {
                message = "Send a new password success!",
                status = 200,
            };

        }
    }
}
