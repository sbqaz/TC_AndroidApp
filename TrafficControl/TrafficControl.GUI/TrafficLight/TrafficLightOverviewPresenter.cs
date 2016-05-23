using System.Collections.Generic;
using Android.App;
using Android.Widget;
using TrafficControl.BLL;
using TrafficControl.BLL.TrafficLight;
using TrafficControl.DAL.RestSharp.Types;

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

        public List<Installation> GetTrafficLights()
        {
            return _model.TrafficLights;
        }
        public void TrafficLightClicked(Activity activity, object sender, AdapterView.ItemClickEventArgs e)
        {
            string text = string.Format("Trafficlight Adress: {0}\n" +
                                        "Trafficlight Id: {1}\n" +
                                        "Længdegrad: {2}\n" +
                                        "Breddegrad: {3}", GetTrafficLights()[e.Position].Name, GetTrafficLights()[e.Position].Id, GetTrafficLights()[e.Position].Position.Longtitude, GetTrafficLights()[e.Position].Position.Latitude);

            new AlertDialog.Builder(activity).SetPositiveButton("Ok", (msender, args) => { })
                                                            .SetMessage(text)
                                                            .SetTitle("Trafficlight")
                                                            .Show();
        }
    }
}