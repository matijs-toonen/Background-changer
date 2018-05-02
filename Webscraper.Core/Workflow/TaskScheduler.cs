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
        private static readonly List<string> ScheduledTasks = new List<string>();
        public static string ExecutableLocation {get; set;}
        public static string TaskTitle = "Desktop Wallpaper changer";

        public static void CreateTask()
        {
            using (var taskService = new TaskService())
            {
                var task = taskService.RootFolder.AllTasks.FirstOrDefault(x => x.Name == TaskTitle);
                TaskDefinition taskDefinition = task?.Definition ?? taskService.NewTask();

                taskDefinition.RegistrationInfo.Description = "Changes the desktop wallpaper every hour";

                var logonTrigger = new LogonTrigger();
                logonTrigger.Repetition.Interval = TimeSpan.FromHours(1);

                var creationTrigger = new RegistrationTrigger();
                creationTrigger.Repetition.Interval = TimeSpan.FromHours(1);

                taskDefinition.Triggers.Clear();
                taskDefinition.Actions.Clear();

                taskDefinition.Triggers.Add(logonTrigger);
                taskDefinition.Triggers.Add(creationTrigger);
                taskDefinition.Actions.Add(new ExecAction(ExecutableLocation));
                taskDefinition.Settings.DisallowStartIfOnBatteries = false;
                taskDefinition.Settings.MultipleInstances = TaskInstancesPolicy.StopExisting;
                taskDefinition.Settings.StopIfGoingOnBatteries = false;

                taskService.RootFolder.RegisterTaskDefinition(TaskTitle, taskDefinition);
                ScheduledTasks.Add(TaskTitle);
            }
        }

        /// <summary>
        /// Delete all created tasks since the start of the application
        /// </summary>
        public static void DeleteAllTasks()
        {
            using (var taskService = new TaskService())
            {
                foreach (var scheduledTask in ScheduledTasks)
                {
                    taskService.RootFolder.DeleteTask(scheduledTask);
                }
            }
        }
    }
}