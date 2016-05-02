using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

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