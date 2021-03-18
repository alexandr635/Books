using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Books.Infrastructure.Interfaces
{
    public interface IConverterService
    {
        Task<byte[]> ImageToByte(IFormFile file);
    }
}
