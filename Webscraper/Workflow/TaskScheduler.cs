using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Win32.TaskScheduler;

namespace Webscraper.Workflow
{
    public static class TaskScheduler
    {
        private static List<string> scheduledTasks = new List<string>();
        public static string TaskTitle = "Desktop Wallpaper changer";

        public static void CreateTask()
        {
            using (var taskService = new TaskService())
            {
                var task = taskService.RootFolder.AllTasks.FirstOrDefault(x => x.Name == TaskTitle);
                if (task != null)
                    return;

                TaskDefinition taskDefination = taskService.NewTask();
                taskDefination.RegistrationInfo.Description = "Changes the desktop wallpaper every hour";

                var logonTrigger = new LogonTrigger();
                logonTrigger.Repetition.Interval = TimeSpan.FromHours(1);

                taskDefination.Triggers.Add(logonTrigger);
                taskDefination.Actions.Add(new ExecAction(@"C:\Development\Webscraper\Webscraper - github\Webscraper\Webscraper\bin\Debug\Webscraper.exe"));
                taskDefination.Settings.DisallowStartIfOnBatteries = false;
                taskDefination.Settings.MultipleInstances = TaskInstancesPolicy.StopExisting;
                taskDefination.Settings.StopIfGoingOnBatteries = false;

                taskService.RootFolder.RegisterTaskDefinition(TaskTitle, taskDefination);
                scheduledTasks.Add(TaskTitle);
            }
        }

        /// <summary>
        /// Delete all created tasks since the start of the application
        /// </summary>
        public static void DeleteAllTasks()
        {
            using (var taskService = new TaskService())
            {
                foreach (var scheduledTask in scheduledTasks)
                {
                    taskService.RootFolder.DeleteTask(scheduledTask);
                }
            }
        }
    }
}