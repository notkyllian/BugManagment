using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taak
{
    internal class UserRepository : Repository<User>
    {
        internal UserRepository()
        {
            Items = new List<User>();
        }

        internal override void AddItem(User entity)
        {
            Items.Add(entity);
        }

        internal override User GetItem(int id)
        {
            return Items.Find(user => user.Id == id);
        }

        internal override List<User> GetAll()
        {
            return Items;
        }

        internal override void RemoveItem(int id)
        {
            Items.Remove(GetItem(id));
        }
    }
}