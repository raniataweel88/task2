
using task2.DTO.Category;
using task2.DTO.Courses;
using task2.DTO.Instructor;
using task2.Models;

namespace task2.Interfaces
{
    public interface IInstractornterface
    {
        //Deals With Instroctor
        Task<List<AddInstractorDTO>> GetInstroctorAsync();
        Task<List<GetAllInstructorDTO>> SearchInstroctorAsync(string? name, string? specification);
        Task<Instructor> GetInstroctorByIdAsync(int Id);
        Task UpdateInstroctor(UpdateInstructorDTO dto);
    
        //Deals With Catogory
        Task<List<CategoryDTO>> GetCatogoryAsync();
        Task<List<CategoryDTO>> SearchCatogoryAsync(string? name);
        Task<Category> GetCatogoryByIdAsync(int Id);
       
    }
}
