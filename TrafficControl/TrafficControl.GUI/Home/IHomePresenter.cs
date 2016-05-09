using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Widget;
using TrafficControl.BLL;
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