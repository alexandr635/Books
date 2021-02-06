using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Logic
{
    public interface IWorkWithBook
    {
        Task<HashSet<Book>> GetBook();
        Task<Book> GetBook(int? id);
        Task AddBook(Book book);
        Task ChangeBook(Book book);
    }
}
