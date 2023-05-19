using BCrypt.Net;
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

    public class LoginController : ControllerBase
    {
        private readonly DbFourSeasonHotelContext db;
        private readonly IConfiguration configuration;
        public UserService userService = new UserService();
        private User userCurrent;
        public LoginController(DbFourSeasonHotelContext db, IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody] Login login)
        {
            try
            {
                var result = userService.Login(login.email, login.password, configuration);
                return Ok(result);
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
                var result = await userService.Register(user);
                return Ok(result);
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
                _user.Status = "1";
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

    public class Login
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
