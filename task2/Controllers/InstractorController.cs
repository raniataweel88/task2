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
    public class InstractorController : ControllerBase, IInstractornterface
    {
        private readonly CoursesDbContext _context;
        public InstractorController(CoursesDbContext context)
        {
            _context = context;
        }
        #region Instroctor
        [HttpGet]
        [Route("GetInstroctor")]
        public async Task<List<AddInstractorDTO>> GetInstroctorAsync()
        {
            var Instructors = await _context.Instructors.ToListAsync();
            var result = from In in Instructors
                         select new AddInstractorDTO
                         {
                             InstructorId = In.InstructorId,
                             Name = In.Name,
                             Email = In.Email,
                             PhoneNumber = In.PhoneNumber,
                             Age = In.Age,
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
        [Route("UpdateInstroctor")]
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
        [HttpGet]
        [Route("[action]")]
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
        
        #endregion
        #region Catogory
        [HttpGet]
        [Route("getCatogory")]
        public async Task<List<CategoryDTO>> GetCatogoryAsync()
        {
            var Category = await _context.Categorys.ToListAsync();
            var result = from c in Category
                         select new CategoryDTO
                         {
                             Name = c.Name,
                             CategoryId = c.CategoryId,
                             Description = c.Description,

                         };
            return (result.ToList());
        }
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

            #endregion

        }
    }
}