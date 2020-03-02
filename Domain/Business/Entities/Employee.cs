using System;
using System.Collections.Generic;

namespace Domain.Business.Entities
{
    public class Employee : User
    {
        private readonly List<Task> _todo;

        internal Employee(int id, string name, DateTime birthday, string password, string username) : base(id, name,
            birthday, password, username)
        {
            _todo = new List<Task>();
        }

        internal void AddTask(Task task)
        {
            _todo.Add(task);
        }

        internal void Load(List<Task> tasks)
        {
            _todo.AddRange(tasks);
        }
    }
}