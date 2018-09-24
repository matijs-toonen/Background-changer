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
            key.SetValue("SubCommands", "Next;Previous;BlackList");
            key.SetValue("Position", "bottom");

            key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Next", true);
            key.SetValue("@", "Next");
            key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Next\command", true);
            key.SetValue("", Assembly.GetAssembly(typeof(WallpaperChanger)).Location);

            key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Previous", true);
            key.SetValue("@", "Previous");
            key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Previous\command", true);
            key.SetValue("", Assembly.GetAssembly(typeof(WallpaperChanger)).Location + " Previous");

            key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\BlackList", true);
            key.SetValue("@", "BlackList");
            key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\Blacklist\command", true);
            key.SetValue("", Assembly.GetAssembly(typeof(WallpaperChanger)).Location + " BlackList");
        }
    }
}
