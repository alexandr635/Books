using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        BookContext Context { get; set; }

        public UserRepository(BookContext context)
        {
            Context = context;
        }

        public async Task<Entities.User> GetUser(Entities.User user)
        {
            var currentUser = await Task.Run( () => 
                Context.Users.Include("Role").FirstOrDefault(u => u.Login == user.Login && u.Password == user.Password)
            );
            if (currentUser != null)
                return currentUser;
            else
                return null;
        }

        public async Task<Entities.User> GetUser(string login)
        {
            var user = await Task.Run( () => 
            Context.Users.FirstOrDefault(u => u.Login == login));

            return user;
        }
    }
}
