using Books.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAuthor();
        Task<List<Author>> GetAuthor(string pattern);
        Task<Author> GetAuthor(int? id);
        Task AddAuthor(Author author);
        Task ChangeAuthor(Author author);
        Task DeleteAuthor(Author author);
        Task<int> GetMaxYear();
        Task<int> GetMinYear();
        Task<List<Author>> GetAuthor(Author author);
    }
}
