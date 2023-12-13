using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task2.Context;
using task2.DTO;
using task2.Interfaces;
using task2.Models;

namespace task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase ,IUserInterface
    {
        private readonly CoursesDbContext _context;
        public UserController(CoursesDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Login")]
        public async Task Login(LoginDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Email))
                throw new Exception("Email Is Required");
            if (string.IsNullOrEmpty(dto.Password))
                throw new Exception("Password Is Required");
            var user = _context.Users.SingleOrDefault(x =>
            x.Email.Equals(dto.Email) && x.Password.Equals(dto.Password));
            if (user != null)
            {
                if (!user.IsLoggedIn)
                {
                    user.IsLoggedIn = true;
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }

                else
                    throw new Exception("You're Already LoggedIn ");

            }
            else
            {
                throw new Exception("Either Email or Password is Incorrect");
            }
        }

      

        [HttpPut]
        [Route("Logout")]
        public async Task Logout(int UserId)
        {
            var user = await _context.Users.FindAsync(UserId);
            if (user != null)
            {
                user.IsLoggedIn = false;
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
        }
      
    }
}
