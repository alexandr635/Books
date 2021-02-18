using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Logic
{
    public class AuthorRepository : IAuthorRepository
    {
        BookContext Context { get; set; }

        public AuthorRepository(BookContext Context)
        {
            this.Context = Context;
        }

        public async Task<List<Author>> GetAuthor()
        {
            return await Context.Authors.ToListAsync();
        }

        public async Task<List<Author>> GetAuthor(string pattern)
        {
            try
            {
                DateTime date = Convert.ToDateTime(pattern);
                return await Context.Authors.Where(a => a.DateOfBirth == date || a.DateOfDie == date).ToListAsync();
            }
            catch
            {
                return await Context.Authors.Where(u => u.Name.Contains(pattern) ||
                                                        u.LastName.Contains(pattern) ||
                                                        u.Patronymic.Contains(pattern)).ToListAsync();
            }
        }

        public async Task<Author> GetAuthor(int? id)
        {
            return await Context.Authors.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAuthor(Author author)
        {
            await Context.Authors.AddAsync(author);
            await Context.SaveChangesAsync();
        }

        public async Task ChangeAuthor(Author author)
        {
            Context.Update(author);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAuthor(Author author)
        {
            Context.Authors.Remove(author);
            await Context.SaveChangesAsync();
        }
    }
}
