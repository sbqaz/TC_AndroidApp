using System.Collections.Generic;
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
        List<Case> GetMyCases();
        void FetchMyCases();
        void FetchCases();
        void OnPause();
    }
}