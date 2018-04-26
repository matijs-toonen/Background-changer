using System;
using ImageSetter.Workflow;
using Webscraper.Core.Workflow;

namespace ImageSetter
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = @"http://1920x1080hdwallpapers.com/anime/";
            TaskScheduler.CreateTask();
            WallpaperChanger.ImageSetter(url);
            Environment.Exit(0);
        }
    }
}
