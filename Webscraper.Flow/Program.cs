using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Webscraper.Core.Workflow;

namespace Webscraper.Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskScheduler.CreateTask();
            ImageSetter.Program.Main(args);
        }
    }
}
