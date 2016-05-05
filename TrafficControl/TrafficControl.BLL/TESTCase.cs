using System;

namespace TrafficControl.BLL
{
    public class TESTCase
    {
        public enum States
        {
            Closed,
            Open,
            Taken
        }

        public TESTCase(string name, long id, DateTime timeStamp, States state)
        {
            Name = name;
            Id = id;
            State = state;
            TimeStamp = timeStamp;
        }

        public string Name { get; }
        public long Id { get; }
        public DateTime TimeStamp { get; }
        public States State { get; }
    }
}