using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TrafficControl.BLL;
using TrafficControl.BLL.Lyskryds;

namespace TrafficControl.GUI
{
    public class TrafficLightOverviewPresenter : ITrafficViewOverViewPresenter
    {
        private readonly ITrafficLightOverviewView _view;
        private readonly ITrafficLightOverviewModel _model;

        public TrafficLightOverviewPresenter(ITrafficLightOverviewView view, ITrafficLightOverviewModel model)
        {
            _view = view;
            _model = model;
        }

        public List<TrafficLightList> GetTrafficLights()
        {
            return _model.TrafficLights;
        }
        public void TrafficLightClicked(Activity activity, object sender, AdapterView.ItemClickEventArgs e)
        {
            string text = string.Format("Trafficlight Adress: {0}\n" +
                                        "Trafficlight Id: {1}", GetTrafficLights()[e.Position].Adresse, GetTrafficLights()[e.Position].Id);

            new AlertDialog.Builder(activity).SetPositiveButton("Ok", (msender, args) => { })
                                                            .SetMessage(text)
                                                            .SetTitle("Trafficlight")
                                                            .Show();
        }
    }
}