using Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Logic
{
    public interface IBookQuery
    {
        Task<BookDTO> GetBook(int? id);
        Task<HashSet<BookDTO>> GetBook();
        Task<HashSet<BookDTO>> GetBook(string pattern);
        Task AddBook(BookDTO book);
        Task ChangeBook(BookDTO book);
        Task<HashSet<BookDTO>> GetRatingList(int size);

    }
}
