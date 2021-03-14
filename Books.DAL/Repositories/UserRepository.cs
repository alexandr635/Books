using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        ApplicationContext Context { get; set; }

        public UserRepository(ApplicationContext context)
        {
            Context = context;
        }

        public async Task<User> GetUser(User user)
        {
            return await Context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Login == user.Login && u.Password == user.Password);
        }

        public async Task<User> GetUser(string login)
        {
            return await Context.Users
                .Include(u => u.Role)
                .Include(u => u.BookRents)
                .Include(u => u.UserToBooks)
                .FirstOrDefaultAsync(u => u.Login == login);
        }

        public async Task<User> GetUserWithBooks(string login)
        {
            var user = await Context.Users
                .Include(u => u.Role)
                .Include(u => u.BookRents)
                .Include(u => u.UserToBooks)
                .FirstOrDefaultAsync(u => u.Login == login);

            foreach (var book in user.UserToBooks)
                book.SetBook(await Context.Books.FirstOrDefaultAsync(b => b.Id == book.Id));

            return user;
        }

        public async Task<List<User>> GetUser()
        {
            return await Context.Users.ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await Context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task ChangeUser(User user)
        {
            Context.Users.Update(user);
            await Context.SaveChangesAsync();
        }

        public async Task ChangeUserRole(User user)
        {
            Context.Entry(user).Property(u => u.RoleId == user.RoleId).IsModified = true;
            await Context.SaveChangesAsync();
        }

        public async Task DeleteUser(User user)
        {
            Context.Users.Remove(user);
            await Context.SaveChangesAsync();
        }

        public async Task AddUser(User user)
        {
            Context.Users.Add(user);
            await Context.SaveChangesAsync();
        }

        public async Task AddUserRent(BookRent rent)
        {
            Context.Users.FirstOrDefault(u => u.Id == rent.UserId).BookRents.Add(rent);
            await Context.SaveChangesAsync();
        }

        public async Task AddUserFavorite(UserToBook favorite)
        {
            Context.Users.FirstOrDefault(u => u.Id == favorite.UserId).UserToBooks.Add(favorite);
            await Context.SaveChangesAsync();
        }
    }
}
