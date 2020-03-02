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

        public Employee Employee { get; internal set; }
        public Bug Bug { get; internal set; }
        public string Description { get; internal set; }
        public int Size { get; internal set; }
        public TimeSpan TimeSpent { get; internal set; }

        internal void AddTime(TimeSpan time)
        {
            TimeSpent += time;
        }
    }
}