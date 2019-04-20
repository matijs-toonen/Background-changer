using System;
using ImageSetter.Workflow;

namespace ImageSetter
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string url = @"http://1920x1080hdwallpapers.com/anime/";
            WallpaperChanger.ImageSetter(url, args);
            Environment.Exit(0);
        }
    }
}
