using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ImageSetter.Workflow;
using Webscraper.Core.Workflow;

namespace Webscraper.Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskScheduler.ExecutableLocation = Assembly.GetAssembly(typeof(WallpaperChanger)).Location;
            TaskScheduler.CreateTask();
            ImageSetter.Program.Main(args);
        }
    }
}
