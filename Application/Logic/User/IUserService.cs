using Application.DTO;
using System.Threading.Tasks;

namespace Application.Logic.User
{
    public interface IUserService
    {
        Task<UserDTO> GetUser(UserDTO user);
        Task<UserDTO> GetUser(string login);
    }
}
