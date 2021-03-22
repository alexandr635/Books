using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Books.Infrastructure.Interfaces
{
    public interface IFileService
    {
        Task<string> AddBookFile(IFormFile file);
        Task<string> AddImageFile(IFormFile file);
        void DeleteFile(string path);
    }
}
