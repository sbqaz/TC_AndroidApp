using System.Collections.Generic;
using TrafficControl.BLL.Observer;

namespace TrafficControl.BLL.Home
{
    public interface IHomeModel : ISubject<IHomeModel>
    {
        List<Case> Cases { get; } 
    }
}