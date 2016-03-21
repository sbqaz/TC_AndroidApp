using System;
using System.Collections.Generic;
using System.Threading;
using TrafficControl.BLL.Observer;

namespace TrafficControl.BLL.Home
{
    public class HomeModel : Subject<IHomeModel>, IHomeModel
    {
        private long _caseCounter = 0;
        private readonly List<Case> _cases;

        public Case NewCase { get; set; }

        //Fjern cases fra View'et (HomeActivity)
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
                _caseCounter++;
                string tmp = string.Format("Case {0}", _caseCounter);
                NewCase = new Case(tmp, _caseCounter, (Case.States)(i%3));
                Cases.Add(new Case(tmp, _caseCounter, (Case.States)(i % 3)));
                Notify(this);
            }
        }
    }
}