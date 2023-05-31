using BigBang_Assessment.Db;
using BigBang_Assessment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BigBang_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly HotelContext _context;

        private const string UserRole = "User";
        private const string AdminRole = "Admin";

        public LoginController(IConfiguration config, HotelContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost("User")]
        public async Task<IActionResult> Post(User _userData)
        {
            if (_userData != null && _userData.Username != null && _userData.Password != null)
            {
                var user = await GetUser(_userData.Username, _userData.Password);

                if (user != null)
                {

                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Username", user.Username ?? string.Empty),
                        new Claim("Email",user.Email ?? string.Empty),
                        new Claim("Password",user.Password ?? string.Empty),
                        new Claim(ClaimTypes.Role, UserRole)

                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<User?> GetUser(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }


        [HttpPost("Admin")]
        public async Task<IActionResult> PostAdmin(Admin _adminData)
        {
            if (_adminData != null && _adminData.Admin_Name != null && _adminData.Admin_Password != null)
            {
                var admin = await GetAdmin(_adminData.Admin_Name, _adminData.Admin_Password);

                if (admin != null)
                {

                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Username", admin.Admin_Name ?? string.Empty),
                        new Claim("Password",admin.Admin_Password ?? string.Empty),
                        new Claim(ClaimTypes.Role, AdminRole)

                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<Admin?> GetAdmin(string adminname, string adminpassword)
        {
            return await _context.Admins.FirstOrDefaultAsync(u => u.Admin_Name == adminname && u.Admin_Password == adminpassword);
        }
    }
}
