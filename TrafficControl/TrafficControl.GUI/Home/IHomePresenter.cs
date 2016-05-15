using System.Collections.Generic;
using System.Threading.Tasks;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.GUI.Home
{
    public interface IHomePresenter
    {
        void OnDestroy();
        List<Case> GetCases();
        Task<List<Case>> GetCasesAsync();
        List<Case> GetMyCases();
    }
}