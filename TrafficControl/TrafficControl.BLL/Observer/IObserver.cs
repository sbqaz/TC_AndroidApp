namespace TrafficControl.BLL.Observer
{
    public interface IObserver<T>
    {
        void Update(T subject);
    }
}