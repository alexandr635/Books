using System.Threading.Tasks;

namespace Data.Repositories.User
{
    public interface IUserRepository
    {
        Task<Entities.User> GetUser(Entities.User user);
        Task<Entities.User> GetUser(string login);
    }
}
