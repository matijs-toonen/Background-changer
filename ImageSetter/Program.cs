using System;
using System.Reflection;
using ImageSetter.Workflow;
using Webscraper.Core.Workflow;

namespace ImageSetter
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string url = @"http://1920x1080hdwallpapers.com/anime/";
            WallpaperChanger.ImageSetter(url);
            Environment.Exit(0);
        }
    }
}
