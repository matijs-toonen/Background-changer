using System;
using ImageSetter.Workflow;

namespace ImageSetter
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            WallpaperChanger.ImageSetter(args);
            Environment.Exit(0);
        }
    }
}
