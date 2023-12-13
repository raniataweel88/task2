
using task2.DTO;
using task2.Models;

namespace task2.Interfaces
{
    public interface IUserInterface
    {
        Task Login(LoginDTO dto);
        Task Logout(int UserId);
    }
}
