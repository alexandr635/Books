using Books.Domain.Entities;
using System.Threading.Tasks;

namespace Books.Infrastructure.Interfaces
{
    public interface IUserService
    {
        Task DeleteUser(int id);
        Task<User> AddUser(User user);
        Task<User> AddUserRent(int id, string name);
        Task<User> AddUserFavorite(int id, string name);
    }
}
