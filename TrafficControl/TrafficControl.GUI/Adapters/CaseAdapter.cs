using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.GUI.Adapters
{
    public class CaseAdapter : BaseAdapter
    {
        private Activity _activity;

        //From model instead??
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
            var caseTime = view.FindViewById<TextView>(Resource.Id.case_time);
            var caseIcon = view.FindViewById<ImageView>(Resource.Id.CaseIcon);
            caseName.Text = _cases[position].Installation.Name;
            caseId.Text = string.Format("Fejlbeskrivelse: {0}", _cases[position].ErrorDescription);
            caseTime.Text = string.Format("Oprettet: {0}", _cases[position].Time != null ? _cases[position].Time.Value.ToString("dd-MMM-yyyy ddd") : "n/a");//"Oprettet: " + _cases[position].Time.ToString("dd-MMM-yyyy ddd");
            caseName.SetTextColor(_activity.Resources.GetColor(Resource.Color.ForeGround));
            caseId.SetTextColor(_activity.Resources.GetColor(Android.Resource.Color.DarkerGray));
            caseTime.SetTextColor(_activity.Resources.GetColor(Android.Resource.Color.DarkerGray));

            switch ((int)_cases[position].Status)
            {
                case 0:
                    //caseName.SetTextColor(_activity.Resources.GetColor(Resource.Color.CaseClosed));
                    caseIcon.SetImageResource(Resource.Drawable.TCLogoGreen);
                    break;
                case 1:
                    //caseName.SetTextColor(_activity.Resources.GetColor(Resource.Color.CaseOpen));
                    caseIcon.SetImageResource(Resource.Drawable.TCLogoYellow);
                    break;
                case 2:
                    //caseName.SetTextColor(_activity.Resources.GetColor(Resource.Color.CaseTaken));
                    caseIcon.SetImageResource(Resource.Drawable.TCLogoRed);
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