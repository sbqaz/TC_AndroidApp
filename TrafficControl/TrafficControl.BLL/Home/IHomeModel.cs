using System.Collections.Generic;
using TrafficControl.BLL.Observer;

namespace TrafficControl.BLL.Home
{
    public interface IHomeModel : ISubject<IHomeModel>
    {
        Case NewCase { get; }
    }
}