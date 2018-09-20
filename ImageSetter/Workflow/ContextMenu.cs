using Microsoft.Win32;
using System.Reflection;

namespace ImageSetter.Workflow
{
    public static class ContextMenu
    {
        public static void CreateContextMenu()
        {
            var key = Registry.ClassesRoot.CreateSubKey(@"DesktopBackground\Shell\Wallpaper", true);
            key.SetValue("MUIVerb", "Wallpaper Settings");
            key.SetValue("SubCommands", "Next;BlackList");
            key.SetValue("Position", "bottom");

            key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Next", true);
            key.SetValue("@", "Next");
            key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Next\command", true);
            key.SetValue("", Assembly.GetAssembly(typeof(WallpaperChanger)).Location + " /arg1 contextMenu");
            
            key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\BlackList", true);
            key.SetValue("@", "BlackList");
        }
    }
}
