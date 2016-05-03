using System.Collections;
using System.Collections.Generic;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.BLL.Map
{
    public interface IMapModel
    {
        IEnumerable<Installation> Installations { get; }
    }
}