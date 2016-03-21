namespace TrafficControl.BLL.Observer
{
    public interface ISubject<T>
    {
        void Attach(IObserver<T> o);
        void Detach(IObserver<T> o);
        void Notify(T subject);
    }
}