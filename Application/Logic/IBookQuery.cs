using Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Logic
{
    public interface IBookQuery
    {
        Task<BookDTO> GetBook(int? id);
        Task<List<BookDTO>> GetBook();
        Task AddBook(BookDTO book);
        Task ChangeBook(BookDTO book);

    }
}
