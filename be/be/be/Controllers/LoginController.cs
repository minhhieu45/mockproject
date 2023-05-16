using be.Helpers;
using be.Models;
using be.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Xml.Linq;

namespace be.Controllers
{
    [ApiController]
    [Route("api")]
    public class Login
    {
        public string email { get; set; }
        public string password { get; set; }
    }
    public class LoginController : ControllerBase
    {
        private readonly DbFourSeasonHotelContext db;
        private readonly IConfiguration configuration;
        public UserService userService = new UserService();
        public LoginController(DbFourSeasonHotelContext db, IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] Login login)
        {
            try
            {
                if (!ValidateHelper.Instance.IsMail(login.email))
                {
                    return Ok(new
                    {
                        status = 404,
                        message = "Email is not validate"
                    });
                }

                string token = "";
                var user = await db.Users.FirstOrDefaultAsync(x => x.Email == login.email);
                if (user == null)
                {
                    return Ok(new
                    {
                        status = 404,
                        message = "The account is not found"
                    });
                }
                if (!BCrypt.Net.BCrypt.Verify(login.password, user.Password))
                {
                    return Ok(new
                    {
                        message = "Password is wrong",
                        status = 400
                    });
                }
                token = userService.CreateToken(user.Email, user?.RoleId, configuration);
                return Ok(new
                {
                    message = "Login success",
                    status = 200,
                    data = user,
                    token
                });
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody]User user)
        {
            try
            {
                if ((db.Users?.Any(x => x.Email == user.Email)).GetValueOrDefault())
                {
                    return Ok(new
                    {
                        message = "Email is found",
                        status = 400
                    });
                }
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                db.Users.Add(user);
                await db.SaveChangesAsync();
                var _user = await db.Users.Where(x => x.Email == user.Email).FirstOrDefaultAsync();

                return Ok(new
                {
                    message = "Add account success!",
                    status = 200,
                    data = _user,
                });
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("confirm")]
        public async Task<ActionResult> ConfirmAccount(int id)
        {
            try
            {
                var _user = await db.Users.FindAsync(id);
                if (_user == null)
                {
                    return NotFound();
                }
                _user.Status = "";
                db.Entry(await db.Users.FirstOrDefaultAsync(x => x.UserId == id)).CurrentValues.SetValues(_user);
                await db.SaveChangesAsync();
                return Ok(new
                {
                    status = 200,
                    message = "Confirm success"
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
