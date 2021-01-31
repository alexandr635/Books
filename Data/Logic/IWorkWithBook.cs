using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Logic
{
    public interface IWorkWithBook
    {
        Task<List<Book>> GetBook();
        Task<Book> GetBook(int? id);
        Task AddBook(Book book);
        Task ChangeBook(Book book);
    }
}
