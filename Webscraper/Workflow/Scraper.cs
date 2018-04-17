using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Webscraper.Workflow
{
    public static class Scraper
    {
        public static WebClient webclient { get; set; }

        public static HtmlDocument GetAllImages(string url)
        {
            webclient = new WebClient();
            string source = webclient.DownloadString(url);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(source);
            return document;
        }
    }
}
