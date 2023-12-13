
using task2.DTO.Courses;
using task2.Models;

namespace task2.Interfaces
{
    public interface ISharedInterface 
    {
        //Manage Courses
        Task<List<GetAllCoursesDTO>> SearchCoursesAsync(string? name, int? price);
        Task<Courses> GetCoursesByIdAsync(int Id);
        Task<List<GetAllCoursesDTO>> GetCoursesAsync();
      
    }
}
