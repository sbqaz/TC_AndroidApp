using System.Collections.Generic;
using Android.App;
using Android.Widget;
using TrafficControl.BLL;

namespace TrafficControl.GUI.Home
{
    public interface IHomePresenter
    {
        void OnDestroy();
        List<Case> GetCases();
        List<Case> GetMyCases(); 
        void CaseItemClicked(Activity activity, object sender, AdapterView.ItemClickEventArgs e);
    }
}