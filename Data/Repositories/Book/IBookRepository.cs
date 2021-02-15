using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Logic
{
    public interface IBookRepository
    {
        Task<HashSet<Book>> GetBook();
        Task<HashSet<Book>> GetBook(string pattern);
        Task<Book> GetBook(int? id);
        Task AddBook(Book book);
        Task ChangeBook(Book book);
        Task<HashSet<Book>> GetRatingList(int size);
        Task DeleteBook(Book book);
        Task<HashSet<Book>> GetBook(Book book);
    }
}
