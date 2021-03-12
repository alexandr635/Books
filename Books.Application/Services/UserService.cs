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

        public async Task<User> AddUser(User user)
        {
            var check = await UserRepository.GetUser(user.Login);
            if (check != null)
                return null;
            else
            {
                user.SetRole(4);
                await UserRepository.AddUser(user);
                var res = await UserRepository.GetUser(user.Login);
                return res;
            }
        }
    }
}
