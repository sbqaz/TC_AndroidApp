using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TrafficControl.BLL.Observer;
using TrafficControl.DAL.RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.BLL.Home
{
    public class HomeModel : Subject<IHomeModel>, IHomeModel
    {
        private readonly List<Case> _cases;
        private readonly List<Case> _myCases;

        private ITCApi _api;

        public List<Case> Cases
        {
            get { return _cases; }
        }

        public List<Case> MyCases
        {
            get { return _myCases; }
        }

        public HomeModel(ITCApi api) : base()
        {
            _api = api;
            _cases = new List<Case>();
            _myCases = new List<Case>();
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
                var newCase = new Case(tmp, tmpID, RandomDay(), (Case.States) (i%3));
                Cases.Add(newCase);
                if(i == 0 || newCase.Id % 2 == 0 && newCase.State == Case.States.Open)
                    MyCases.Add(newCase);
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