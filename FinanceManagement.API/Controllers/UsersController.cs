using FinanceManagement.DATA.Data;
using FinanceManagement.DOMAIN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly FinanceDbContext _context;

        public UsersController(FinanceDbContext context)
        {
            _context = context;         
        }

        // POST: api/User/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register(User user)
        {
            if (_context.Users.Any(u => u.UserName == user.UserName))
            {
                return BadRequest("Username already exists.");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully" });
        }

        // POST: api/User/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login(User user)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == user.UserName && u.Password == user.Password); // Note: Use hashed passwords in a real application

            if (existingUser == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(new { message = "Login successful" });
        }
    }
}
