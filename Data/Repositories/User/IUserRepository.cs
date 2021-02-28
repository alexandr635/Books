using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.User
{
    public interface IUserRepository
    {
        Task<Entities.User> GetUser(Entities.User user);
        Task<Entities.User> GetUser(string login);
        Task<List<Entities.User>> GetUser();
        Task<Entities.User> GetUser(int id);
        Task ChangeUser(Entities.User user);
        Task DeleteUser(Entities.User user);
        Task AddUser(Entities.User user);
    }
}
