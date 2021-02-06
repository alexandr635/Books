using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Logic
{
    public class WorkWithGenre : IWorkWithGenre
    {
        BookContext context { get; set; }

        public WorkWithGenre(BookContext context)
        {
            this.context = context;
        }

        public async Task<HashSet<Genre>> GetGenre()
        {
            var res = await Task.Run( () => context.Genres.ToHashSet());
            return res;
        }

        public async Task<Genre> GetGenre(int? id)
        {
            var res = await Task.Run(() => context.Genres.AsNoTracking().FirstOrDefault(g => g.Id == id));
            return res;
        }

        public async Task AddGenre(Genre genre)
        {
            await context.Genres.AddAsync(genre);
            await context.SaveChangesAsync();
        }

        public async Task ChangeGenre(Genre genre)
        {
            context.Update(genre);
            await context.SaveChangesAsync();
        }
    }
}
