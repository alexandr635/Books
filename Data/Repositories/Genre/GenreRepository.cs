using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<List<Genre>> GetGenre()
        {
            return await Task.Run( () => Context.Genres.ToListAsync());
        }

        public async Task<Genre> GetGenre(int? id)
        {
            return await Context.Genres.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id);
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
