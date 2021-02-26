using Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Logic
{
    public interface IBookService
    {
        Task<BookDTO> GetBook(int? id);
        Task<List<BookDTO>> GetBook();
        Task<List<BookDTO>> GetBook(string pattern);
        Task AddBook(BookDTO book);
        Task ChangeBook(BookDTO book);
        Task<List<BookDTO>> GetRatingList(int size);
        Task DeleteBook(BookDTO bookDTO);
        Task<List<BookDTO>> GetBook(BookDTO book);
        Task ChangeBookStatus(BookDTO book);
        Task ChangeBookImage(BookDTO book);
    }
}
