using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TrafficControl.BLL.Observer;
using TrafficControl.DAL.RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.BLL.TrafficLight
{
    public class TrafficLightOverviewModel : Subject<ITrafficLightOverviewModel>, ITrafficLightOverviewModel
    {
        private readonly ITCApi _api;
        private List<Installation> _trafficLights;

        public List<Installation> TrafficLights
        {
            get
            {
                _trafficLights = _api.GetInstallations().ToList();
                return _trafficLights;
            }
        }

        public TrafficLightOverviewModel(ITCApi api) : base()
        {
            _api = api;
            _trafficLights = new List<Installation>();
            ThreadPool.QueueUserWorkItem(o => SlowMethod());
        }

        //For TESTING
        private void SlowMethod()
        {
            //for (int i = 0; i < 50; i++)
            //{
            //    Thread.Sleep(3000);
            //    string tmp = RandomString(3) + " - " + RandomString(3);
            //    var tmpID = random.Next(1000) + 2500;
            //    var newTrafficLight = new TrafficLightList(tmp, tmpID, (TrafficLightList.States)(i % 3), 1, 1);
            //    TrafficLights.Add(newTrafficLight);
            //    if (i == 0 || newTrafficLight.Id % 2 == 0 && newTrafficLight.State == TrafficLightList.States.Running)
            //        TrafficLights.Add(newTrafficLight);
            //    Notify(this);
            //}
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