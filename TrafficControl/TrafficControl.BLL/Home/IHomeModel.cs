using System.Collections.Generic;
using System.Threading.Tasks;
using TrafficControl.BLL.Observer;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.BLL.Home
{
    public interface IHomeModel
    {
        List<Case> Cases { get; }
        List<Case> MyCases { get; }
    }
}