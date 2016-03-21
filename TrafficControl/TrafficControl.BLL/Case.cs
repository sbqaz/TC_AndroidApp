namespace TrafficControl.BLL
{
    public class Case
    {
        public enum States
        {
            Closed,
            Open,
            Taken
        }

        public Case(string name, long id, States state)
        {
            Name = name;
            Id = id;
            State = state;
        }

        public string Name { get; }
        public long Id { get; }
        public States State { get; }
    }
}