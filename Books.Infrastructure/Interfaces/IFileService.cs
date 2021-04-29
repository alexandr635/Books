using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Books.Infrastructure.Interfaces
{
    public interface IFileService
    {
        Task<string> AddBookDocument(IFormFile file);
        Task<string> AddBookCover(IFormFile file);
        void DeleteBookDocument(string path);
        void DeleteBookCover(string path);
        byte[] GetBookDocument(string bookName);
    }
}
