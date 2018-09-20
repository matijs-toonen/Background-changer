using System;
using System.Linq;
using ImageSetter.Workflow;

namespace ImageSetter
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string url = @"http://1920x1080hdwallpapers.com/anime/";
            WallpaperChanger.ImageSetter(url);

            var argument = args.FirstOrDefault();
            if (argument == null)
                ContextMenu.CreateContextMenu();
               
            Environment.Exit(0);
        }
    }
}
