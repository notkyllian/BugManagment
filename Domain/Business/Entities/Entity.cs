namespace Domain.Business.Entities
{
    public class Entity
    {
        internal Entity(int id)
        {
            Id = id;
        }

        public int Id { get; internal set; }
    }
}