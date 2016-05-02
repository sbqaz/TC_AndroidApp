using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using TrafficControl.BLL;

namespace TrafficControl.GUI
{
    public interface ITrafficViewOverViewPresenter
    {
        List<TrafficLightList> GetTrafficLights();
        void TrafficLightClicked(Activity activity, object sender, AdapterView.ItemClickEventArgs e);
    }
}
