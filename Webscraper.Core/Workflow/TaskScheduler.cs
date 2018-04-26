using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32.TaskScheduler;

namespace Webscraper.Core.Workflow
{
    /// <summary>
    /// https://dahall.github.io/TaskScheduler/html/N_Microsoft_Win32_TaskScheduler.htm
    /// </summary>
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

                var creationTrigger = new RegistrationTrigger();
                creationTrigger.Repetition.Interval = TimeSpan.FromHours(1);

                taskDefination.Triggers.Add(logonTrigger);
                taskDefination.Triggers.Add(creationTrigger);
                taskDefination.Actions.Add(new ExecAction(@"C:\Development\Webscraper\Webscraper-github\Webscraper\ImageSetter\bin\Debug\ImageSetter.exe"));
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