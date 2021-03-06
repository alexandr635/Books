using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.DAL.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        ApplicationContext Context { get; set; }

        public GenreRepository(ApplicationContext Context)
        {
            this.Context = Context;
        }

        public async Task<List<Genre>> GetGenre()
        {
            return await Context.Genres.ToListAsync();
        }

        public async Task<Genre> GetGenre(int? id)
        {
            return await Context.Genres
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Id == id);
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
