using System.Collections.Generic;
using Domain.Business.Entities;

namespace Domain.Business.Repositories
{
    internal class UserRepository : Repository<User>
    {

        internal override void AddItem(User entity)
        {
            Items.Add(entity);
            Persistence.Controller.AddUser(entity);
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
            Persistence.Controller.DeleteUser(GetItem(id));
            Items.Remove(GetItem(id));

        }

        internal override void Load(List<User> itemList)
        {
            Items = itemList ?? new List<User>();
        }

        internal override User UpdateItem(User entity)
        {
            Persistence.Controller.UpdateUser(entity);



            throw new System.NotImplementedException();
        }
    }
}