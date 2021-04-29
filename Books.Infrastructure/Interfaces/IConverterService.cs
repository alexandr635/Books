using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Books.Infrastructure.Interfaces
{
    public interface IConverterService
    {
        Task<byte[]> ImageToByte(IFormFile file);
        Task<string> HtmlToPdf(string path);
        Task<string> WordToHtml(string path);
        Task<string> WordToPdf(string path);
        Task<string> Fb2ToXml(string path);
        Task<string> Fb2sXmlToHtml(string path);
        Task<string> Fb2ToPdf(string path);
        Task<string> RtfToHtml(string path);
        Task<string> RtfToPdf(string path);
        Task<string> TxtToPdf(string path);
        Task<string> EpubsXmlToHtml(string path);
        Task<string> EpubToPdf(string path);
    }
}
