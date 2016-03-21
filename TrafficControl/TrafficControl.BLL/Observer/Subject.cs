using System.Collections.Generic;

namespace TrafficControl.BLL.Observer
{
    public abstract class Subject<T> : ISubject<T>
    {
        private List<IObserver<T>> _observerList;

        public Subject()
        {
            _observerList = new List<IObserver<T>>();
        }

        public void Attach(IObserver<T> o)
        {
            _observerList.Add(o);
        }

        public void Detach(IObserver<T> o)
        {
            _observerList.Remove(o);
        }

        //Add second parameter to indicate whats being notified? Or is generics enough?
        public void Notify(T subject)
        {
            foreach (var o in _observerList)
            {
                o.Update(subject);
            }
        }
    }
}