using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task2.Context;
using task2.DTO.Category;
using task2.DTO.Courses;
using task2.DTO.Instructor;
using task2.Interfaces;
using task2.Models;

namespace task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Centercontroller : ControllerBase, ICenterInterface
    {
        private readonly CoursesDbContext _context;
        public Centercontroller(CoursesDbContext context)
        {
            _context = context;
        }
        #region Courses
        [HttpPost]
        [Route("CreateNewCourses")]
        public async Task CreateNewCourses([FromBody] CourseCradDTO dto)
        {
            Courses cor = new Courses();
            cor.Name = dto.Name;
            cor.Description = dto.Description;
            cor.CoursesId = dto.CoursesId;
            await _context.AddAsync(cor);
            await _context.SaveChangesAsync();
        }
        [HttpPut]
        [Route("[action]")]
        public async Task UpdateCourses(UpdateCoursesDTO dto)
        {
            //check if the element exisit
            var result = await _context.Courses.FindAsync(dto.CoursesId);
            if (result != null)
            {
                //replcaement 
                result.CoursesId = dto.CoursesId;
                result.InstructorName = dto.InstructorName;
                result.Price = dto.Price;
                result.StartingDate = dto.StartingDate;
                result.ExpiryDate = dto.ExpiryDate;
                //update
                _context.Update(result);
                //save changes 
                await _context.SaveChangesAsync();
            }
        }
        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task DeleteCourses([FromRoute] int Id)
        {
            //check if the element exisit
            var result = await _context.Courses.FindAsync(Id);
            if (result != null)
            {
                //delete element 
                _context.Remove(result);
                //savechanges
                await _context.SaveChangesAsync();
            }
        }
        #endregion
        
        #region Instroctor
        [HttpPost]
        [Route("CreatNewInstroctor")]
        public async Task CreatNewInstroctorAsync([FromBody] AddInstractorDTO dto)
        {
            Instructor In = new Instructor();
            In.Name = dto.Name;
            In.InstructorId = dto.InstructorId;
            In.Email = dto.Email;
            In.PhoneNumber = dto.PhoneNumber;
            In.Specifcation = dto.Specifcation;
            await _context.AddAsync(In);
            await _context.SaveChangesAsync();
        }
        [HttpGet]
        public async Task<List<GetAllInstructorDTO>> SearchInstroctorAsync(string? name, string? specification)
        {
            var Instructors = await _context.Instructors.ToListAsync();
            if (name != null)
                Instructors = Instructors.Where(x => x.Name.Contains(name)).ToList();
            if (specification != null)
                Instructors = Instructors.Where(x => x.Name.Contains(specification)).ToList();
            var result = from In in Instructors
                         select new GetAllInstructorDTO
                         {
                             InstructorId = In.InstructorId,
                             Name = In.Name,
                             Email = In.Email,
                             PhoneNumber = In.PhoneNumber,
                             Age = In.Age,
                             Salary = In.Salary,
                             Specifcation = In.Specifcation,
                         };
            return (result.ToList());
        }

        [HttpGet]
        [Route("GetInstrcotorById/{Id}")]
        public async Task<Instructor> GetInstroctorByIdAsync([FromRoute] int Id)
        {
            var result = await _context.Instructors.FindAsync(Id);
            return result;
        }
        [HttpPut]
        [Route("[action]")]
        public async Task UpdateInstroctor(UpdateInstructorDTO dto)
        {
            //check if the element exisit
            var result = await _context.Instructors.FindAsync(dto.InstructorId);
            if (result != null)
            {
                //replcaement 
                result.InstructorId = dto.InstructorId;
                result.Name = dto.Name;
                result.Email = dto.Email;
                result.PhoneNumber = dto.PhoneNumber;
                result.Age = dto.Age;
                result.Salary = dto.SalIary;
                //update
                _context.Update(result);
                //save changes 
                await _context.SaveChangesAsync();
            }
        }
        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task DeleteInstroctor([FromRoute] int Id)
        {
            //check if the element exisit
            var result = await _context.Instructors.FindAsync(Id);
            if (result != null)
            {
                //delete element 
                _context.Remove(result);
                //savechanges
                await _context.SaveChangesAsync();
            }
        }
        #endregion
       
        #region Catogory
        [HttpGet]
        [Route("SearchCatogory")]
        public async Task<List<CategoryDTO>> SearchCatogoryAsync(string? name)
        {
            var categories = await _context.Categorys.ToListAsync();
            if (name != null)
                categories = categories.Where(x => x.Name.Contains(name)).ToList();
            var result = from c in categories
                         select new CategoryDTO
                         {
                             Name = c.Name,
                             CategoryId = c.CategoryId,
                             Description = c.Description,

                         };
            return (result.ToList());
        }
        [HttpGet]
        [Route("GetCatogoryById/{Id}")]
        public async Task<Category> GetCatogoryByIdAsync([FromRoute] int Id)
        {
            var result = await _context.Categorys.FindAsync(Id);
            return result;
        }
        [HttpPost]
        public async Task CreatNewCatogoryAsync([FromBody] CategoryDTO dto)
        {
            Category ex = new Category();
            ex.CategoryId = dto.CategoryId;
            ex.Description = dto.Description;
            ex.Name = dto.Name;
            await _context.AddAsync(ex);
            await _context.SaveChangesAsync();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task UpdateCatogory(CategoryDTO dto)
        {
            //check if the element exisit
            var result = await _context.Categorys.FindAsync(dto.CategoryId);
            if (result != null)
            {
                //replcaement 
                result.Name = dto.Name;
                result.Description = dto.Description;
                result.CategoryId = dto.CategoryId;
                //update
                _context.Update(result);
                //save changes 
                await _context.SaveChangesAsync();
            }
        }
        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task DeleteCatogory([FromRoute] int Id)
        {
            //check if the element exisit
            var result = await _context.Categorys.FindAsync(Id);
            if (result != null)
            {
                //delete element 
                _context.Remove(result);
                //savechanges
                await _context.SaveChangesAsync();
            }
        }

        #endregion

    }
}