using System.Diagnostics;
using System.Reflection;
using ImageSetter.Workflow;
using Webscraper.Core.Workflow;

namespace Webscraper.Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            var executableLocation = Assembly.GetAssembly(typeof(WallpaperChanger)).Location;
            TaskScheduler.ExecutableLocation = executableLocation;
            ContextMenu.CreateContextMenu();
            TaskScheduler.CreateTask();
            Process.Start(executableLocation);
        }
    }
}
