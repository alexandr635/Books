using Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Logic
{
    public interface IWorkWithAuthor
    {
        Task<List<Author>> GetAuthor();
        Task<IQueryable<Author>> GetAuthor(string pattern);
        Task<Author> GetAuthor(int? id);
        Task AddAuthor(Author author);
        Task ChangeAuthor(Author author);
    }
}
