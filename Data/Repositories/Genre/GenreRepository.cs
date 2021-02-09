using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Logic
{
    public class GenreRepository : IGenreRepository
    {
        BookContext Context { get; set; }

        public GenreRepository(BookContext Context)
        {
            this.Context = Context;
        }

        public async Task<HashSet<Genre>> GetGenre()
        {
            var res = await Task.Run( () => Context.Genres.ToHashSet());

            return res;
        }

        public async Task<Genre> GetGenre(int? id)
        {
            var res = await Task.Run(() => Context.Genres.AsNoTracking().FirstOrDefault(g => g.Id == id));

            return res;
        }

        public async Task AddGenre(Genre genre)
        {
            await Context.Genres.AddAsync(genre);
            await Context.SaveChangesAsync();
        }

        public async Task ChangeGenre(Genre genre)
        {
            Context.Update(genre);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteGenre(Genre genre)
        {
            Context.Genres.Remove(genre);
            await Context.SaveChangesAsync();
        }
    }
}
