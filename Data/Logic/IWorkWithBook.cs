using System.Collections.Generic;

namespace Data.Logic
{
    public interface IWorkWithBook
    {
        List<Book> GetBook();
        Book GetBook(int? id);
        void AddBook(Book book);
        void ChangeBook(Book book);
    }
}
