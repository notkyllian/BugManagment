using System;

namespace Domain.Business.Entities
{
    public class Task : Entity
    {
        internal Task(int id, Bug bug, string description, int size, TimeSpan timeSpent) : base(id)
        {
            Bug = bug;
            Size = size;
            TimeSpent = timeSpent;
            Description = description;
        }

        public Employee Employee { get; set; }
        public Bug Bug { get; internal set; }
        public string Description { get; set; }
        public int Size { get; set; }
        public TimeSpan TimeSpent { get; set; }

        internal void AddTime(TimeSpan time)
        {
            TimeSpent += time;
        }
    }
}