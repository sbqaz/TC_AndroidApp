using System;
using System.Collections.Generic;
using System.Threading;
using TrafficControl.BLL.Observer;

namespace TrafficControl.BLL.Home
{
    public class HomeModel : Subject<IHomeModel>, IHomeModel
    {
        public Case NewCase { get; set; }

        //Fjern cases fra View'et (HomeActivity)
        private List<Case> _cases;

        private long _caseCounter = 0;
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
                _cases.Add(NewCase);
                Notify(this);
            }
        }
    }
}