using Books.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(User user);
        Task<User> GetUser(string login);
        Task<List<User>> GetUser();
        Task<User> GetUser(int id);
        Task ChangeUser(User user);
        Task DeleteUser(User user);
        Task AddUser(User user);
    }
}
