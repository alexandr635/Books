using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Logic
{
    public class WorkWithAuthor : IWorkWithAuthor
    {
        BookContext context { get; set; }

        public WorkWithAuthor(BookContext context)
        {
            this.context = context;
        }

        public async Task<List<Author>> GetAuthor()
        {
            var res = await Task.Run( () => context.Authors.ToList());
            return res;
        }

        public async Task<IQueryable<Author>> GetAuthor(string pattern)
        {
            var res = await Task.Run(() => context.Authors.Where(u => u.Name.Contains(pattern) || 
                                                                      u.LastName.Contains(pattern) ||
                                                                      u.Patronymic.Contains(pattern)));
            return res;
        }

        public async Task<Author> GetAuthor(int? id)
        {
            var result = await Task.Run( () => context.Authors.AsNoTracking().FirstOrDefault(a => a.Id == id));
            return result;
        }

        public async Task AddAuthor(Author author)
        {
            await Task.Run( () =>
            {
                context.Authors.Add(author);
                context.SaveChanges();
            });
        }

        public async Task ChangeAuthor(Author author)
        {
            await Task.Run( () =>
            {
                context.Entry(author).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            });
        }
    }
}
