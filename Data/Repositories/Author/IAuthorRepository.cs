using Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Logic
{
    public interface IAuthorRepository
    {
        Task<HashSet<Author>> GetAuthor();
        Task<IQueryable<Author>> GetAuthor(string pattern);
        Task<Author> GetAuthor(int? id);
        Task AddAuthor(Author author);
        Task ChangeAuthor(Author author);
        Task DeleteAuthor(Author author);
    }
}
