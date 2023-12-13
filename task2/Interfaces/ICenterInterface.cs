
using task2.DTO.Category;
using task2.DTO.Courses;
using task2.DTO.Instructor;
using task2.Models;

namespace task2.Interfaces
{
    public interface ICenterInterface
    {
        //Manage Courses
        Task CreateNewCourses(CourseCradDTO dto);
        Task UpdateCourses(UpdateCoursesDTO dto);
        Task DeleteCourses(int Id);
        //Deals With Instroctor
        Task CreatNewInstroctorAsync(AddInstractorDTO dto);
        Task<List<GetAllInstructorDTO>> SearchInstroctorAsync(string? name, string? specification);
        Task<Instructor> GetInstroctorByIdAsync(int Id);
        Task UpdateInstroctor(UpdateInstructorDTO dto);
        Task DeleteInstroctor(int Id);
        //Deals With Catogory
        Task CreatNewCatogoryAsync(CategoryDTO dto);
        Task UpdateCatogory(CategoryDTO dto);
        Task DeleteCatogory(int Id);
    }
}
