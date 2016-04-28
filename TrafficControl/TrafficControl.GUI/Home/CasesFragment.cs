using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using TrafficControl.BLL;
using TrafficControl.GUI.Adapters;

namespace TrafficControl.GUI.Home
{
    public class CasesFragment : Fragment
    {
        private Button _createCaseBtn;
        public ListView CaseView { get; private set; }
        public Activity ContextActivity { get; private set; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            ContextActivity = base.Activity;

            var view = inflater.Inflate(Resource.Layout.CasesFragment, container, false);

            CaseView = view.FindViewById<ListView>(Resource.Id.CaseListing);

            _createCaseBtn = view.FindViewById<Button>(Resource.Id.CreateCaseBtn);
            _createCaseBtn.Click += OnCreateCaseBtnClicked;

            return view;
        }

        private void OnCreateCaseBtnClicked(object sender, EventArgs e)
        {
            if (GetType() != typeof(CreateCaseActivity))
            {
                var nextActivity = new Intent(Activity, typeof(CreateCaseActivity));
                nextActivity.AddFlags(ActivityFlags.ReorderToFront);
                StartActivity(nextActivity);
            }
        }
    }
}