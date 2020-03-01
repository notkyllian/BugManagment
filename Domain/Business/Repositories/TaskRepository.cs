using System.Collections.Generic;
using System.Linq;
using Domain.Business.Entities;

namespace Domain.Business.Repositories
{
    internal class TaskRepository : Repository<Task>
    {

        internal override void AddItem(Task entity)
        {
            Items.Add(entity);
            Persistence.Controller.AddTask(entity);
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
            Task task = GetItem(id);
            Items.Remove(task);
            Persistence.Controller.RemoveTask(task);
        }

        internal override void Load(List<Task> list)
        {
            Items = list ?? new List<Task>();
        }

        internal override Task UpdateItem(Task entity)
        {
            var item = Items.First(d => d.Id == entity.Id);
            item.Description = entity.Description;
            item.Employee = entity.Employee;
            item.Size = entity.Size;
            item.TimeSpent = entity.TimeSpent;
            Persistence.Controller.UpdateTask(item);
            return GetItem(entity.Id);
        }
    }
}