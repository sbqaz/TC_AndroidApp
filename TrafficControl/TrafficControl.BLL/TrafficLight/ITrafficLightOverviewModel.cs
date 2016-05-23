using System.Collections.Generic;
using TrafficControl.BLL.Observer;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.BLL.TrafficLight
{
    public interface ITrafficLightOverviewModel : ISubject<ITrafficLightOverviewModel>
    {
        List<Installation> TrafficLights { get; }
    }
}