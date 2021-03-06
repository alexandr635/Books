using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Books.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Books.Application.Services
{
    public class UserService : IUserService
    {
        IUserRepository UserRepository { get; set; }

        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public async Task DeleteUser(int id)
        {
            User user = new User(id);
            await UserRepository.DeleteUser(user);
        }
    }
}
