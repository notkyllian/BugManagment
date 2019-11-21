using System.Collections.Generic;

namespace Taak
{
    internal class BugRepository : Repository<Bug>
    {
        public BugRepository()
        {
            Items = new List<Bug>();
        }

        internal override void AddItem(Bug entity)
        {
            Items.Add(entity);
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
            Items.Remove(GetItem(id));
        }
    }
}