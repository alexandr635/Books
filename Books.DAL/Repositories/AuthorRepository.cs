using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.DAL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        ApplicationContext Context { get; set; }

        public AuthorRepository(ApplicationContext Context)
        {
            this.Context = Context;
        }

        public async Task<List<Author>> GetAuthor()
        {
            return await Context.Authors.ToListAsync();
        }

        public async Task<int> GetMaxYear()
        {
            return (await Context.Authors.MaxAsync(a => a.DateOfBirth)).Year;
        }

        public async Task<int> GetMinYear()
        {
            return (await Context.Authors.MinAsync(a => a.DateOfBirth)).Year;
        }

        public async Task<List<Author>> GetAuthor(string pattern)
        {
            try
            {
                DateTime date = Convert.ToDateTime(pattern);
                return await Context.Authors
                    .Where(a => a.DateOfBirth == date || a.DateOfDie == date)
                    .ToListAsync();
            }
            catch
            {
                return await Context.Authors
                    .Where(u => u.Name.Contains(pattern) ||
                           u.LastName.Contains(pattern) ||
                           u.Patronymic.Contains(pattern))
                    .ToListAsync();
            }
        }

        public async Task<Author> GetAuthor(int? id)
        {
            return await Context.Authors
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Author>> GetAuthor(Author author)
        {
            List<Author> authors = new List<Author>();
            if (author.Name != null)
            {
                authors = await Context.Authors.
                    Where(a =>
                               (a.Name.Contains(author.Name) ||
                                a.LastName.Contains(author.Name) ||
                                a.Patronymic.Contains(author.Name)) &&
                               a.DateOfBirth >= author.DateOfBirth &&
                               (a.DateOfDie <= author.DateOfDie ||
                                (a.DateOfDie == null && a.DateOfBirth < author.DateOfDie)))
                    .ToListAsync();
            }
            else
                authors = await Context.Authors.
                    Where(a =>
                               a.DateOfBirth >= author.DateOfBirth &&
                               (a.DateOfDie <= author.DateOfDie ||
                                (a.DateOfDie == null && a.DateOfBirth < author.DateOfDie)))
                    .ToListAsync();

            return authors;
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
