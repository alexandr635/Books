using Aspose.Words;
using Books.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Books.Application.Services
{
    public class ConverterService : IConverterService
    {
        public async Task<byte[]> ImageToByte(IFormFile file)
        {
            byte[] result;
            using (var target = new MemoryStream())
            {
                await file.CopyToAsync(target);
                result = target.ToArray();
            }

            return result;
        }

        public void WordToPDF(string path)
        {
            Document doc = new Document(path);
            var index = path.LastIndexOf("\\");
            doc.Save(path.Substring(index));
        }
    }
}
