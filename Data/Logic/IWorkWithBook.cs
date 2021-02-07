using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Logic
{
    public interface IWorkWithBook
    {
        Task<HashSet<Book>> GetBook();
        Task<HashSet<Book>> GetBook(string pattern);
        Task<Book> GetBook(int? id);
        Task AddBook(Book book);
        Task ChangeBook(Book book);
        Task<HashSet<Book>> GetRatingList(int size);
    }
}
