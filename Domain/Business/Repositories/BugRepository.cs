using System.Collections.Generic;
using System.Linq;
using Domain.Business.Entities;

namespace Domain.Business.Repositories
{
    internal class BugRepository : Repository<Bug>
    {
        internal override void AddItem(Bug bug)
        {
            Items.Add(bug);
            Persistence.Controller.AddBug(bug);
        }

        internal override Bug GetItem(int id)
        {
            return Items.Find(task => task.Id == id);
        }

        internal override List<Bug> GetAll()
        {
            return Items;
        }

        internal override void RemoveItem(int id)
        {
            var bug = GetItem(id);
            Items.Remove(bug);
            Persistence.Controller.RemoveBug(bug);
        }


        internal override void Load(List<Bug> list)
        {
            Items = list ?? new List<Bug>();
        }

        internal override Bug UpdateItem(Bug entity)
        {
            Items.First(d => d.Id == entity.Id).Description = entity.Description;
            Persistence.Controller.UpdateBug(entity);
            return GetItem(entity.Id);
        }
    }
}