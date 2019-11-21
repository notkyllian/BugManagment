namespace Taak
{
    public class User : Entity
    {
        public string Naam;

        public User(int id, string naam) : base(id)
        {
            Naam = naam;
        }
    }
}