using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TrafficControl.BLL.Observer;

namespace TrafficControl.BLL.Lyskryds
{
    public class TrafficLightOverviewModel : Subject<ITrafficLightOverviewModel>, ITrafficLightOverviewModel
    {
        private readonly List<TrafficLightList> _trafficLights;

        public List<TrafficLightList> TrafficLights
        {
            get { return _trafficLights; }
        }

        public TrafficLightOverviewModel() : base()
        {
            _trafficLights = new List<TrafficLightList>();
            ThreadPool.QueueUserWorkItem(o => SlowMethod());
        }

        //For TESTING
        private void SlowMethod()
        {
            for (int i = 0; i < 50; i++)
            {
                Thread.Sleep(3000);
                string tmp = RandomString(3) + " - " + RandomString(3);
                var tmpID = random.Next(1000) + 2500;
                var newTrafficLight = new TrafficLightList(tmp, tmpID, (TrafficLightList.States)(i % 3), 1, 1);
                TrafficLights.Add(newTrafficLight);
                if (i == 0 || newTrafficLight.Id % 2 == 0 && newTrafficLight.State == TrafficLightList.States.Running)
                    TrafficLights.Add(newTrafficLight);
                Notify(this);
            }
        }

        //RANDOM string generator for TESTING
        private static Random random = new Random((int)DateTime.Now.Ticks);
        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        //RANDOM DateTime generator for TESTING
        private DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }
    }
}