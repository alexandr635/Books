using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Logic
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAuthor();
        Task<List<Author>> GetAuthor(string pattern);
        Task<Author> GetAuthor(int? id);
        Task AddAuthor(Author author);
        Task ChangeAuthor(Author author);
        Task DeleteAuthor(Author author);
    }
}
