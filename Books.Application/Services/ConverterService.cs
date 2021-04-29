using Books.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using OpenXmlPowerTools;
using System.Xml.Linq;
using System.Drawing.Imaging;
using System.Text;
using System.Linq;
using FB2Library;
using System.Xml;
using RtfPipe;
using DinkToPdf;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel;
using System.Collections.Generic;
using EpubSharp;
using ImageFormat = System.Drawing.Imaging.ImageFormat;
using System;

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

        public async Task<string> WordToHtml(string path)
        {
            byte[] byteArray = File.ReadAllBytes(path);
            string newPath = path.Substring(0, path.LastIndexOf(".")) + ".html";

            using (MemoryStream memoryStream = new MemoryStream())
            {
                await memoryStream.WriteAsync(byteArray, 0, byteArray.Length);
                using (WordprocessingDocument doc = WordprocessingDocument.Open(memoryStream, true))
                {
                    int imageCounter = 0;
                    
                    WmlToHtmlConverterSettings settings = new WmlToHtmlConverterSettings()
                    {
                        PageTitle = path[(path.LastIndexOf("\\") + 1)..],
                        AdditionalCss = "body { margin: 1cm auto; max-width: 20cm; padding: 0; }",
                        FabricateCssClasses = true,
                        CssClassPrefix = "pt-",
                        RestrictToSupportedLanguages = false,
                        RestrictToSupportedNumberingFormats = false,
                        ImageHandler = imageInfo =>
                        {
                            ++imageCounter;
                            string extension = imageInfo.ContentType.Split('/')[1].ToLower();
                            ImageFormat imageFormat = null;
                            if (extension == "png")
                                imageFormat = ImageFormat.Png;
                            else if (extension == "gif")
                                imageFormat = ImageFormat.Gif;
                            else if (extension == "bmp")
                                imageFormat = ImageFormat.Bmp;
                            else if (extension == "jpeg")
                                imageFormat = ImageFormat.Jpeg;
                            else if (extension == "tiff")
                            {
                                extension = "gif";
                                imageFormat = ImageFormat.Gif;
                            }
                            else if (extension == "x-wmf")
                            {
                                extension = "wmf";
                                imageFormat = ImageFormat.Wmf;
                            }

                            if (imageFormat == null)
                                return null;

                            string base64 = null;
                            try
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    imageInfo.Bitmap.Save(ms, imageFormat);
                                    var ba = ms.ToArray();
                                    base64 = System.Convert.ToBase64String(ba);
                                }
                            }
                            catch (System.Runtime.InteropServices.ExternalException)
                            {
                                return null;
                            }

                            ImageFormat format = imageInfo.Bitmap.RawFormat;
                            ImageCodecInfo codec = ImageCodecInfo.GetImageDecoders().First(c => c.FormatID == format.Guid);
                            string mimeType = codec.MimeType;

                            string imageSource = string.Format("data:{0};base64,{1}", mimeType, base64);

                            XElement img = new XElement(Xhtml.img,
                                new XAttribute(NoNamespace.src, imageSource),
                                imageInfo.ImgStyleAttribute,
                                imageInfo.AltText != null ?
                                    new XAttribute(NoNamespace.alt, imageInfo.AltText) : null);
                            return img;
                        }
                    };
                                        
                    XElement htmlElement = WmlToHtmlConverter.ConvertToHtml(doc, settings);
                    var html = new XDocument(new XDocumentType("html", null, null, null), htmlElement);
                    var htmlString = html.ToString(SaveOptions.DisableFormatting);
                    await File.WriteAllTextAsync(newPath, htmlString, Encoding.UTF8);
                }
            }

            File.Delete(path);

            return newPath;
        }

        public async Task<string> WordToPdf(string path)
        {
            string newPath = await WordToHtml(path);
            string result = await HtmlToPdf(newPath);

            return result;
        }

        public async Task<string> Fb2ToXml(string path)
        {
            Stream stream = new FileStream(path, FileMode.Open);
            var readerSettings = new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Ignore
            };
            var loadSettings = new XmlLoadSettings(readerSettings);

            FB2File file = await new FB2Reader().ReadAsync(stream, loadSettings);
            stream.Close();
            var xml = file.ToXML(false);
            string newPath = path.Substring(0, path.LastIndexOf(".")) + ".xml";
            xml.Save(newPath);

            var xmlString = xml.ToString(SaveOptions.DisableFormatting);
            await File.WriteAllTextAsync(newPath, xmlString, Encoding.UTF8);
            File.Delete(path);

            return newPath;
        }

        public async Task<string> Fb2sXmlToHtml(string path)
        {
            XDocument xml = XDocument.Load(path);
            List<string> list = new List<string>
            {
                "<!DOCTYPE HTML><html><head><title>Your book</title></head>"
            };

            List<string> exceptionTags = new List<string>()
            {
                "<title",
                "</title"
            };

            foreach (var el in xml.Root.Elements())
            {
                if (el.Name.LocalName == "body")
                {
                    string temp = "";
                    foreach(var simbol in el.ToString())
                    {
                        if (simbol == '<')
                        {
                            if (temp != "")
                                list.Add(temp);

                            temp = simbol.ToString();
                        }
                        else if (simbol == '>')
                        {
                            temp += simbol;
                            bool exceptionTag = false;
                            foreach (var tag in exceptionTags)
                                if (temp.Contains(tag))
                                    exceptionTag = true;

                            if (exceptionTag == false && !String.IsNullOrWhiteSpace(temp.Trim(' ')))
                                list.Add(temp);
                            temp = "";
                        }
                        else
                            temp += simbol;
                    }
                }
                else if (el.Name.LocalName == "binary")
                {
                    var value = el.Value;
                    var str = el.Attribute("id").ToString();
                    var id = str.Substring(str.IndexOf('\"') + 1, str.Length - str.IndexOf('\"') - 2);
                    if (id.Contains("cover."))
                    {
                        var index = list.FindIndex(c => c.Contains("<body"));
                        if (index != -1)
                            list.Insert(index + 1, $"<img src='data:image/png;base64, {value}'>");
                    }
                    else
                    {
                        var index = list.FindIndex(c => c.Contains(id));
                        if (index != -1)
                            list[index] = $"<img src='data:image/png;base64, {value}'>";
                    }
                }
            }
            list.Add("</html>");
            var result = String.Join(null, list);
            string newPath = path.Substring(0, path.LastIndexOf(".")) + ".html";
            await File.WriteAllTextAsync(newPath, result, Encoding.UTF8);
            File.Delete(path);

            return newPath;
        }

        public async Task<string> Fb2ToPdf(string path)
        {
            var newPath = await Fb2ToXml(path);
            var lastPath = await Fb2sXmlToHtml(newPath);
            var result = await HtmlToPdf(lastPath);

            return result;
        }

        public async Task<string> RtfToHtml(string path)
        {
            string rtf = string.Empty;
            string newPath = path.Substring(0, path.LastIndexOf(".")) + ".html";

            using (StreamReader sr = new StreamReader(path, Encoding.GetEncoding(1251)))
            {
                rtf = await sr.ReadToEndAsync();
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string htmlString = Rtf.ToHtml(rtf);                        
            await File.WriteAllTextAsync(newPath, htmlString, Encoding.UTF8);
            File.Delete(path);

            return newPath;
        }

        public async Task<string> RtfToPdf(string path)
        {
            string newPath = await RtfToHtml(path);
            string result = await HtmlToPdf(newPath);

            return result;
        }

        public async Task<string> HtmlToPdf(string path)
        {
            string content = "";
            using(StreamReader sr = new StreamReader(path))
            {
                content = await sr.ReadToEndAsync();
            }
            string newPath = path.Substring(0, path.LastIndexOf(".")) + ".pdf";
            string title = path[(path.IndexOf("\\") + 1)..];

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = DinkToPdf.ColorMode.Color,
                    Orientation = DinkToPdf.Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Out = newPath,
                    DocumentTitle = title
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HtmlContent = content,
                        WebSettings = { DefaultEncoding = "utf-8" },
                        HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 }
                    }
                }
            };

            var converter = new BasicConverter(new PdfTools());
            await Task.Run(() => converter.Convert(doc));
            File.Delete(path);

            return newPath;
        }

        public async Task<string> TxtToPdf(string path)
        {
            List<string> textFileLines = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    textFileLines.Add(await sr.ReadLineAsync());
                }
            }

            MigraDoc.DocumentObjectModel.Document doc = new MigraDoc.DocumentObjectModel.Document();
            Section section = doc.AddSection();

            var font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 15)
            {
                Bold = true
            };

            foreach (string line in textFileLines)
            {
                Paragraph paragraph = section.AddParagraph();
                paragraph.AddFormattedText(line, font);
            }

            string newPath = path.Substring(0, path.LastIndexOf(".")) + ".pdf";
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true)
            {
                Document = doc
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(newPath);
            File.Delete(path);
            
            return newPath;
        }

        public async Task<string> EpubsXmlToHtml(string path)
        {
            EpubBook book = EpubReader.Read(path);
            var html = book.Resources.Html;
            var css = book.Resources.Css;
            var img = book.Resources.Images;

            //add html
            string contentString = "";
            foreach (var line in html)
            {
                contentString += line.TextContent;
            }

            List<string> exceptionTags = new List<string>()
            {
                "<!DOCTYPE",
                "<html",
                "</html",
                "<head",
                "</head",
                "<meta",
                "</meta",
                "<style",
                "</style",
                "<body",
                "</body",
                "<link",
                "</link",
                "<title",
                "</title"
            };

            List<string> list = new List<string>
            {
                "<!DOCTYPE html><html><head><title>Your book</title></head><body>"
            };

            string tempString = "";
            bool styleTag = false;
            foreach (var simbol in contentString)
            {
                if (simbol == '<')
                {
                    if (tempString != "" && styleTag == false)
                        list.Add(tempString);
                    tempString = simbol.ToString();
                }
                else if (simbol == '>')
                {
                    tempString += simbol;
                    bool exceptionTag = false;
                    
                    foreach (var tag in exceptionTags)
                        if (tempString.Contains(tag))
                            exceptionTag = true;
                    if (tempString.Contains("<style") || tempString.Contains("<title"))
                        styleTag = true;
                    else if (tempString.Contains("</style") || tempString.Contains("</title"))
                        styleTag = false;
                    if (exceptionTag == false && tempString != "")
                        list.Add(tempString);

                    tempString = "";
                }
                else
                    tempString += simbol;
            }

            //add img
            tempString = "";
            foreach (var image in img)
            {
                var index = list.FindIndex(l => l.Contains(image.FileName));
                if (index != -1)
                    list[index] = $"<img src='data:image/png;base64, {Convert.ToBase64String(image.Content)}'>";
            };

            list.Add("</body></html>");
            var result = String.Join(null, list);
            string newPath = path.Substring(0, path.LastIndexOf(".")) + ".html";
            await File.WriteAllTextAsync(newPath, result, Encoding.UTF8);
            File.Delete(path);

            return newPath;
        }

        public async Task<string> EpubToPdf(string path)
        {
            string newPath = await EpubsXmlToHtml(path);
            string result = await HtmlToPdf(newPath);

            return result;
        }
    }
}