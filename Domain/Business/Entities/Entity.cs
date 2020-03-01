namespace Domain.Business.Entities
{
    public class Entity
    {
        private int id;

        public int Id
        {
            get => id;
            internal set => id = value;
        }

        internal Entity(int id)
        {
            Id = id;
        }
    }
}