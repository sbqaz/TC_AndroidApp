namespace TrafficControl.BLL
{
    public class TrafficLightList
    {
        public enum States
        {
            Running,
            Error
        }
        public TrafficLightList(string adress, long id, States state, int longitude, int latitude)
        {
            Adresse = adress;
            Id = id;
            State = state;
            Longitude = longitude;
            Latitude = latitude;
        }

        public string Adresse { get; }
        public long Id { get; }
        public States State { get; }
        public int Longitude { get; }
        public int Latitude { get; }
    }
}