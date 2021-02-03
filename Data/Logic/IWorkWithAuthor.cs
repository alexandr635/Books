using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Logic
{
    public interface IWorkWithAuthor
    {
        Task<List<Author>> GetAuthor();
        Task<Author> GetAuthor(int? id);
        Task AddAuthor(Author author);
        Task ChangeAuthor(Author author);
    }
}
