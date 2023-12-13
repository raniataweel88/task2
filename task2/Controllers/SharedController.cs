using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task2.Context;
using task2.DTO.Courses;
using task2.Interfaces;
using task2.Models;

namespace task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedController : ControllerBase, ISharedInterface
    {
        private readonly CoursesDbContext _context;
        public SharedController(CoursesDbContext context)
        {
            _context = context;
        }

        #region Course

        [HttpGet]
        [Route("getCourse")]
        public async Task<List<GetAllCoursesDTO>> GetCoursesAsync()
        {
            var Course = await _context.Courses.ToListAsync();
            var result = from C in Course
                         select new GetAllCoursesDTO
                         {
                             Name = C.Name,
                             CoursesId = C.CoursesId,
                             Price = C.Price,
                             InstructorName = C.InstructorName,
                             Description = C.Description,
                             StartingDate = C.StartingDate,
                             ExpiryDate = C.ExpiryDate,

                         };
            return (result.ToList());
        }
        [HttpGet]
        [Route("SearchCourses")]
        public async Task<List<GetAllCoursesDTO>> SearchCoursesAsync(string? name, int? price)
        {
            var Course = await _context.Courses.ToListAsync();
            if (name != null)
                Course = Course.Where(x => x.Name.Contains(name)).ToList();
            if (price != null)
                Course = Course.Where(x => x.Price >= price).ToList();
            var result = from C in Course
                         select new GetAllCoursesDTO
                         {
                             Name = C.Name,
                             CoursesId = C.CoursesId,
                             Price = C.Price,
                             InstructorName = C.InstructorName,
                             Description = C.Description,
                             StartingDate = C.StartingDate,
                             ExpiryDate = C.ExpiryDate,

                         };
            return (result.ToList());
        }
        [HttpGet]
        [Route("GetCoursesById/{Id}")]
        public async Task<Courses> GetCoursesByIdAsync([FromRoute] int Id)
        {
            var result = await _context.Courses.FindAsync(Id);
            return result;
        
        }
    

        #endregion
     
    }
}