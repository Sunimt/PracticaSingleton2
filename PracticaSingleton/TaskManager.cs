using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaSingleton
{
    public sealed class TaskManager
    {
        private static TaskManager instance = null;
        private static readonly object padlock = new object();
        private List<Task> tasks = new List<Task>();
        private int nextId = 1;

        private TaskManager() { }
        public static TaskManager Instance {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new TaskManager();
                    }
                    return instance;
                }
            }
        }

        public async Task<Task> CreateTask(string taskName, string taskDescription,string status, string priority)
        {
            var newTask = new Task(
                nextId++,
                taskName,
                taskDescription,
                status,
                priority
                );
            tasks.Add(newTask);
            return newTask;
        }
        public List<Task> GetTasks()
        {
            return tasks;
        }
    }
}
