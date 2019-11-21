using System.Collections.Generic;

namespace Taak
{
    internal class TaskRepository : Repository<Task>
    {
        internal TaskRepository()
        {
            Items = new List<Task>();
        }

        internal override void AddItem(Task entity)
        {
            Items.Add(entity);
        }

        internal override Task GetItem(int id)
        {
            return Items.Find(task => task.Id == id);
        }

        internal override List<Task> GetAll()
        {
            return Items;
        }

        internal override void RemoveItem(int id)
        {
            Items.Remove(GetItem(id));
        }
    }
}