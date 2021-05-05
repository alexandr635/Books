using Books.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Books.Application.Services
{
    public class FileService : IFileService
    {
        const string bookFolder = "\\wwwroot\\Files\\Books\\";
        const string coverFolder = "/wwwroot/Files/Covers/";

        IConverterService ConverterService { get; set; }

        public FileService(IConverterService converterService)
        {
            ConverterService = converterService;
        }

        public async Task<string> AddBookDocument(IFormFile file)
        {
            string filePath = Directory.GetCurrentDirectory() + bookFolder + file.FileName;
            var list = new List<string>()
            {
                "application/octet-stream",
                "text/html",
                "text/plain",
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                "application/msword",
                "application/epub+zip"
            };

            if (!File.Exists(filePath) && list.Contains(file.ContentType))
            {
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }
            
                string fullPath = Path.GetFullPath(filePath);

                switch (file.ContentType)
                {
                    case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                    case "application/msword":
                        if (file.FileName.Contains(".rtf"))
                            filePath = await ConverterService.RtfToPdf(fullPath);
                        else
                            filePath = await ConverterService.WordToPdf(fullPath);
                        break;
                    case "application/epub+zip":
                        filePath = await ConverterService.EpubToPdf(fullPath);
                        break;
                    case "application/octet-stream":
                        filePath = await ConverterService.Fb2ToPdf(fullPath);
                        break;
                    case "text/html":
                        filePath = await ConverterService.HtmlToPdf(fullPath);                        
                        break;
                    case "text/plain":
                        filePath = await ConverterService.TxtToPdf(fullPath);
                        break;
                }
                filePath = filePath[(filePath.LastIndexOf("\\") + 1)..];

                return filePath;
            }
            throw new System.Exception("Недопустимое расширение файла");
        }

        public async Task<string> AddBookCover(IFormFile file)
        {
            string filePath = Directory.GetCurrentDirectory() + coverFolder + file.FileName;

            if (file.ContentType.Contains("image/"))
            {
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }
            }
            else
                throw new System.Exception("Ты втираешь мне какую-то дичь");

            return file.FileName;
        }

        public void DeleteBookCover(string path)
        {
            var fullPath = Directory.GetCurrentDirectory() + coverFolder + path;
            File.Delete(fullPath);
        }

        public void DeleteBookDocument(string path)
        {
            var fullPath = Directory.GetCurrentDirectory() + bookFolder + path;
            File.Delete(fullPath);
        }

        public byte[] GetBookDocument(string bookName)
        {
            string path = Directory.GetCurrentDirectory() + bookFolder + bookName;
            WebClient User = new WebClient();
            byte[] buffer = null;
            if (File.Exists(path))
                buffer = User.DownloadData(path);

            return buffer;
        }
    }
}
