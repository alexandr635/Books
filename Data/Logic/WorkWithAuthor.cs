using Data.Entities;
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

        public async Task<Author> GetAuthor(int? id)
        {
            var result = await Task.Run( () => context.Authors.FirstOrDefault(a => a.Id == id));
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
