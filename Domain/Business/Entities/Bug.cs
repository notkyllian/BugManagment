using System.Collections.Generic;

namespace Domain.Business.Entities
{
    public class Bug : Entity
    {
        public List<Task> Tasks;

        public Bug(int id, string description) : base(id)
        {
            Tasks = new List<Task>();
            Description = description;
        }

        public string Description { get; set; }


        public int GetTaskCount()
        {
            return Tasks.Count;
        }

        internal void Load(List<Task> taken)
        {
            Tasks = taken;
        }
    }
}