using System.Collections.Generic;
using Android.App;
using System.Collections.Generic;
using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Provider;
using Android.Views;
using Android.Widget;
using Java.Lang;
using TrafficControl.BLL;

namespace TrafficControl.GUI.Adapters
{
    public class TrafficLightListAdapter : BaseAdapter
    {
        private Activity _activity;

        //From model instead??
        private List<TrafficLightList> _trafficlight; 
        public TrafficLightListAdapter(Activity activity, List<TrafficLightList> trafficlight)
        {
            _activity = activity;
            _trafficlight = trafficlight;
        }

        public override Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return _trafficlight[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _activity.LayoutInflater.Inflate(Resource.Layout.TrafficLightItem, parent, false);
            var trafficlightAdresse = view.FindViewById<TextView>(Resource.Id.trafficlight_adress);
            var trafficlightId = view.FindViewById<TextView>(Resource.Id.trafficlight_id);
          
            var trafficLightIcon = view.FindViewById<ImageView>(Resource.Id.TrafficLightIcon);
            trafficlightAdresse.Text = _trafficlight[position].Adresse;
            trafficlightId.Text = string.Format("ID: {0}", _trafficlight[position].Id);
           
            trafficlightAdresse.SetTextColor(_activity.Resources.GetColor(Resource.Color.ForeGround));
            trafficlightId.SetTextColor(_activity.Resources.GetColor(Android.Resource.Color.DarkerGray));
           
            switch (_trafficlight[position].State)
            {
                case TrafficLightList.States.Running:
                    //caseName.SetTextColor(_activity.Resources.GetColor(Resource.Color.CaseClosed));
                    trafficLightIcon.SetImageResource(Resource.Drawable.TCLogoGreen);
                    break;
                case TrafficLightList.States.Error:
                    //caseName.SetTextColor(_activity.Resources.GetColor(Resource.Color.CaseOpen));
                    trafficLightIcon.SetImageResource(Resource.Drawable.TCLogoRed);
                    break;
            }

            return view;
        }

        public override int Count
        {
            get { return _trafficlight.Count; }
        }
    }
}