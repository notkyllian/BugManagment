using System;

namespace Domain.Business.Entities
{
    public class User : Entity
    {
        public string Name;
        public DateTime Birthday;

        public string Username;
        public string Password;


        public User(int id, string name, DateTime birthday, string password, string username) : base(id)
        {
            Name = name;
            Birthday = birthday;
            Password = password;
            Username = username;
        }
    }
}