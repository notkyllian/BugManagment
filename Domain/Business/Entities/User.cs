using System;

namespace Domain.Business.Entities
{
    public class User : Entity
    {
        public DateTime Birthday;
        public string Name;
        public string Password;

        public string Username;


        public User(int id, string name, DateTime birthday,string username,string password) : base(id)
        {
            Name = name;
            Birthday = birthday;
            Password = password;
            Username = username;
        }
    }
}