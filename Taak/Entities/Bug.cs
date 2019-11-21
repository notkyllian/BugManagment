using System.Collections.Generic;

namespace Taak
{
    public class Bug : Entity
    {
        private readonly List<Task> _tasks;

        internal Bug(int id, string description) : base(id)
        {
            _tasks = new List<Task>();
            Description = description;
        }

        public string Description { get; internal set; }

        internal void AddTask(Task task)
        {
            _tasks.Add(task);
        }

        public int GetTaskCount()
        {
            return _tasks.Count;
        }
    }
}