using System.Collections.Generic;
using Android.App;
using Android.Widget;
using TrafficControl.BLL;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.GUI
{
    public interface ITrafficViewOverViewPresenter
    {
        List<Installation> GetTrafficLights();
        void TrafficLightClicked(Activity activity, object sender, AdapterView.ItemClickEventArgs e);
    }
}
