using System.Collections.Generic;
using System.Threading.Tasks;
using TrafficControl.BLL.Observer;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.BLL.Home
{
    public interface IHomeModel : ISubject<IHomeModel>
    {
        List<Case> Cases { get; } 
        List<Case> MyCases { get; }
        void FetchCases();
        void FetchMyCases();

        void Run();
    }
}