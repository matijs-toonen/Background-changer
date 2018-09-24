using System.Reflection;
using ImageSetter.Workflow;
using Webscraper.Core.Workflow;

namespace Webscraper.Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskScheduler.ExecutableLocation = Assembly.GetAssembly(typeof(WallpaperChanger)).Location;
            ContextMenu.CreateContextMenu();
            TaskScheduler.CreateTask();
            ImageSetter.Program.Main(args);
        }
    }
}
