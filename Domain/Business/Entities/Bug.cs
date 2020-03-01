using System.Collections.Generic;

namespace Domain.Business.Entities
{
    public class Bug : Entity
    {
        public List<Task> _tasks;

        public Bug(int id, string description) : base(id)
        {
            _tasks = new List<Task>();
            Description = description;
        }

        public string Description { get; set; }



        public int GetTaskCount()
        {
            return _tasks.Count;
        }

        internal void Load(List<Task> taken)
        {
            _tasks = taken;
        }
    }
}