using Application.DTO;
using System.Collections.Generic;

namespace Application.Logic
{
    public interface IDBQuery
    {
        BookDTO GetBook(int? id);
        List<BookDTO> GetBook();
        void AddBook(BookDTO book);
        void ChangeBook(BookDTO book);

    }
}
