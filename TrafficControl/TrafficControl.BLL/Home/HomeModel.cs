using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TrafficControl.BLL.Observer;

namespace TrafficControl.BLL.Home
{
    public class HomeModel : Subject<IHomeModel>, IHomeModel
    {
        private readonly List<Case> _cases;
        
        public List<Case> Cases
        {
            get { return _cases; }
        }

        public HomeModel() : base()
        {
            _cases = new List<Case>();
            ThreadPool.QueueUserWorkItem(o => SlowMethod());
        }

        private void SlowMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                string tmp = RandomString(3) + " - " + RandomString(3);
                var tmpID = random.Next(1000) + 2500;
                Cases.Add(new Case(tmp, tmpID, RandomDay(), (Case.States)(i % 3)));
                Notify(this);
            }
        }

        //RANDOM string generator for TESTING
        private static Random random = new Random((int)DateTime.Now.Ticks);//thanks to McAden
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
        private Random gen = new Random();
        DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

    }
}