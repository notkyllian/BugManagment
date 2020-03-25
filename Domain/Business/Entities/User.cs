using System;

namespace Domain.Business.Entities
{
    public class User : Entity
    {
        public DateTime Birthday { get; internal set; }
        public string Name { get; internal set; }
        public string Password { get; internal set; }

        public string Username { get; internal set; }


        public User(int id, string name, DateTime birthday,string username,string password) : base(id)
        {
            Name = name;
            Birthday = birthday;
            Password = password;
            Username = username;
        }
    }
}