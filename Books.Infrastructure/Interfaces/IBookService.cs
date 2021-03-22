using Books.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Infrastructure.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetBooksByRole(string role);
        Task<List<Book>> GetBooksByFilter(Book book, string role);
        Task ChangeBook(Book book);
        Task ChangeBookStatus(Book book, string role);
        Task AddBook(Book book);
        Task<Book> SetBookData(Book book, int[] tagsId, IFormFileCollection files);
        Task<byte[]> ReadBook(int id);
    }
}
