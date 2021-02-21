using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Logic
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBook();
        Task<List<Book>> GetBook(string pattern);
        Task<Book> GetBook(int? id);
        Task AddBook(Book book);
        Task ChangeBook(Book book);
        Task<List<Book>> GetRatingList(int size);
        Task DeleteBook(Book book);
        Task<List<Book>> GetBook(Book book);
        Task ChangeBookStatus(Book book);
    }
}
