using be.Helpers;
using be.Models;
using be.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace be.Controllers
{
    [ApiController]
    [Route("api/user")]

    public class UserController : ControllerBase
    {
        public UserService userService = new UserService();
        private readonly DbFourSeasonHotelContext db;
        public UserController(DbFourSeasonHotelContext db)
        {
            this.db = db;
        }
        [HttpGet("info")]
        public async Task<ActionResult> GetInfo(string token)
        {
            string _token = token.Split(' ')[1];
            if (_token == null)
            {
                return Ok(new
                {
                    message = "Token is wrong!",
                    status = 400
                });
            }
            var handle = new JwtSecurityTokenHandler();
            string email = Regex.Match(JsonSerializer.Serialize(handle.ReadJwtToken(_token)), "emailaddress\",\"Value\":\"(.*?)\",").Groups[1].Value;
            var user = db.Users.Where(x => x.Email == email).FirstOrDefault();
            if (user == null)
            {
                return Ok(new
                {
                    message = "User is not found!",
                    status = 404
                });
            }
            return Ok(new
            {
                message = "Get information success!",
                status = 200,
                data = user
            });
        }
        [HttpGet("search")]
        public async Task<ActionResult> GetUserByEmail(string email)
        {
            var user = await db.Users.Where(x => x.Email.Contains(email)).FirstOrDefaultAsync();
            if (user == null)
            {
                return Ok(new
                {
                    status = 404,
                    message = "Email is not found"
                });
            }
            return Ok(new
            {
                status = 200,
                message = "Email is found"
            });
        }
        [HttpPost("forgot")]
        public async Task<ActionResult> ForgotPassword([FromBody] string email)
        {
            try
            {
                var result = await userService.ForgotPassword(email);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
