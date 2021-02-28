using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<List<Entities.User>> GetUser()
        {
            return await Context.Users.ToListAsync();
        }

        public async Task<Entities.User> GetUser(int id)
        {
            return await Context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task ChangeUser(Entities.User user)
        {
            Context.Users.Update(user);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteUser(Entities.User user)
        {
            Context.Users.Remove(user);
            await Context.SaveChangesAsync();
        }

        public async Task AddUser(Entities.User user)
        {
            Context.Users.Add(user);
            await Context.SaveChangesAsync();
        }
    }
}
