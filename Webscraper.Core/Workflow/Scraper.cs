using System.Net;
using HtmlAgilityPack;

namespace Webscraper.Core.Workflow
{
    public static class Scraper
    {
        public static WebClient Webclient { get; set; }

        public static HtmlDocument GetAllImages(string url)
        {
            Webclient = new WebClient();
            string source = Webclient.DownloadString(url);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(source);
            return document;
        }
    }
}
