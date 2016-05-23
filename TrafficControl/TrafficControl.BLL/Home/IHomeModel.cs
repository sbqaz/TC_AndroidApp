using System.Collections.Generic;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.BLL.Home
{
    public interface IHomeModel
    {
        List<Case> Cases { get; }
        List<Case> MyCases { get; }
    }
}