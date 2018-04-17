using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webscraper.Classes;

namespace Webscraper
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = @"http://1920x1080hdwallpapers.com/anime/";
            Worker.ImageSetter(url);
            Environment.Exit(0);
        }
    }
}
