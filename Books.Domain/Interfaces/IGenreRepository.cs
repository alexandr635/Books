using Books.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Domain.Interfaces
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetGenre();
        Task AddGenre(Genre genre);
        Task ChangeGenre(Genre genre);
        Task<Genre> GetGenre(int? id);
        Task DeleteGenre(Genre genre);
        Task DeleteGenre(int id);
    }
}
