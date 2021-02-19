using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
            return await Context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Login == user.Login && u.Password == user.Password);
        }

        public async Task<Entities.User> GetUser(string login)
        {
            return await Context.Users.FirstOrDefaultAsync(u => u.Login == login);
        }
    }
}
