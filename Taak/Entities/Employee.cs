using System.Collections.Generic;

namespace Taak.Entities
{
    public class Employee : User
    {
        private readonly List<Task> _todo;

        internal Employee(int id, string naam) : base(id, naam)
        {
            _todo = new List<Task>();
        }

        internal void AddTask(Task task)
        {
            _todo.Add(task);
        }
    }
}