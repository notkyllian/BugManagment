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
            var item = GetItem(id);
            Persistence.Controller.DeleteUser(item);
            Items.Remove(item);
        }

        internal override void Load(List<User> itemList)
        {
            Items = itemList ?? new List<User>();
        }

        internal override User UpdateItem(User entity)
        {
            var item = GetItem(entity.Id);

            item.Birthday = entity.Birthday;
            item.Name = entity.Name;
            item.Username = entity.Username;
            item.Password = entity.Password;


            Persistence.Controller.UpdateUser(entity);

            return GetItem(entity.Id);
        }
    }
}