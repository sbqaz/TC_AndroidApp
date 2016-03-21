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
    public class CaseAdapter : BaseAdapter
    {
        private Activity _activity;
        private List<Case> _cases; 
        public CaseAdapter(Activity activity, List<Case> cases)
        {
            _activity = activity;
            _cases = cases;
        }

        public override Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return _cases[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _activity.LayoutInflater.Inflate(Resource.Layout.CaseItem, parent, false);
            var caseName = view.FindViewById<TextView>(Resource.Id.case_name);
            var caseId = view.FindViewById<TextView>(Resource.Id.case_id);
            var caseIcon = view.FindViewById<ImageView>(Resource.Id.CaseIcon);
            caseName.Text = _cases[position].Name;
            caseId.Text = _cases[position].Id.ToString();
            caseName.SetTextColor(_activity.Resources.GetColor(Resource.Color.ForeGround));
            caseId.SetTextColor(_activity.Resources.GetColor(Resource.Color.ForeGround));

            switch (_cases[position].State)
            {
                case Case.States.Closed:
                    //caseName.SetTextColor(_activity.Resources.GetColor(Resource.Color.CaseClosed));
                    caseIcon.SetImageResource(Resource.Drawable.TCLogoGreen);
                    break;
                case Case.States.Open:
                    //caseName.SetTextColor(_activity.Resources.GetColor(Resource.Color.CaseOpen));
                    caseIcon.SetImageResource(Resource.Drawable.TCLogoRed);
                    break;
                case Case.States.Taken:
                    //caseName.SetTextColor(_activity.Resources.GetColor(Resource.Color.CaseTaken));
                    caseIcon.SetImageResource(Resource.Drawable.TCLogoYellow);
                    break;
            }

            return view;
        }

        public override int Count
        {
            get { return _cases.Count; }
        }
    }
}