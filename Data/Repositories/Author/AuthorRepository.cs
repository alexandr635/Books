using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<HashSet<Author>> GetAuthor()
        {
            var res = await Task.Run( () => Context.Authors.ToHashSet());

            return res;
        }

        public async Task<IQueryable<Author>> GetAuthor(string pattern)
        {
            var res = await Task.Run(() => Context.Authors.Where(u => u.Name.Contains(pattern) || 
                                                                      u.LastName.Contains(pattern) ||
                                                                      u.Patronymic.Contains(pattern)));
            return res;
        }

        public async Task<Author> GetAuthor(int? id)
        {
            var result = await Task.Run( () => Context.Authors.AsNoTracking().FirstOrDefault(a => a.Id == id));

            return result;
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
