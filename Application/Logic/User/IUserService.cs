using Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Logic.User
{
    public interface IUserService
    {
        Task<UserDTO> GetUser(UserDTO user);
        Task<UserDTO> GetUser(string login);
        Task<List<UserDTO>> GetUser();
        Task<UserDTO> GetUser(int id);
        Task ChangeUser(UserDTO user);
        Task DeleteUser(UserDTO user);
        Task AddUser(UserDTO user);
    }
}
