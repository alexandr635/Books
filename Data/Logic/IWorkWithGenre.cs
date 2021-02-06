using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Logic
{
    public interface IWorkWithGenre
    {
        Task<HashSet<Genre>> GetGenre();
        Task AddGenre(Genre genre);
        Task ChangeGenre(Genre genre);
        Task<Genre> GetGenre(int? id);
    }
}
