using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Logic
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetGenre();
        Task AddGenre(Genre genre);
        Task ChangeGenre(Genre genre);
        Task<Genre> GetGenre(int? id);
        Task DeleteGenre(Genre genre);
    }
}
