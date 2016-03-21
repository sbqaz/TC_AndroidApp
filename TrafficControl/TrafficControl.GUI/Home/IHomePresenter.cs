using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using TrafficControl.BLL;

namespace TrafficControl.GUI.Home
{
    public interface IHomePresenter
    {
        void OnDestroy();
        List<Case> GetCases();
        void CaseItemClicked(Activity activity, object sender, AdapterView.ItemClickEventArgs e);
    }
}