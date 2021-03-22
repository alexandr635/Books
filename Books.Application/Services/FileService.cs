using Books.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Books.Application.Services
{
    public class FileService : IFileService
    {
        public async Task<string> AddBookFile(IFormFile file)
        {
            string path = "\\Files\\Books\\" + file.FileName;
            string directory = Directory.GetCurrentDirectory() + "\\wwwroot\\";

            if (file.ContentType == "application/pdf")
            {
                if (!File.Exists(directory + path))
                {
                    using (var fs = new FileStream(directory + path, FileMode.Create))
                    {
                        await file.CopyToAsync(fs);
                    }
                }
            }
            else
            {
                switch (file.ContentType.Substring(11))
                {
                    case "docx":

                        break;
                }
            }

            return path;
        }

        public async Task<string> AddImageFile(IFormFile file)
        {
            string path = "Files/Covers/" + file.FileName;
            string directory = Directory.GetCurrentDirectory() + "/wwwroot/";

            if (file.ContentType.Contains("image/"))
            {
                using (var fs = new FileStream(directory + path, FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }
            }
            else
            {
                return null;
            }

            return path;
        }

        public void DeleteFile(string path)
        {
            var directory = Directory.GetCurrentDirectory() + "/wwwroot/";
            File.Delete(directory + path);
        }
    }
}
