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
using TrafficControl.BLL;
using TrafficControl.DAL.RestSharp.Types;
using TrafficControl.GUI.Home;

namespace TrafficControl.GUI
{
    [Activity(Label = "CaseActivity")]
    public class CaseActivity : Activity, IHomeView
    {
        private HomePresenter _homePresenter;
        private Case _currentCase; //TODO To Presenter

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ViewCase);

            _homePresenter = new HomePresenter(this, ModelFactory.Instance.CreateHomeModel());

            if (this.Intent.Extras != null)
            {
                var caseId = this.Intent.Extras.GetLong(GetString(Resource.String.PASS_CASE_ID));

                var cases = _homePresenter.GetCases();
                foreach (var @case in cases)
                {
                    if (@case.Id == caseId)
                    {
                        _currentCase = @case;
                    }
                }
            }

            TextView text = FindViewById<TextView>(Resource.Id.testCaseText);
            text.Text = _currentCase.Installation.Name;

            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
        }

        public override bool OnMenuItemSelected(int featureId, IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                Finish();
            }
            return base.OnMenuItemSelected(featureId, item);
        }
    }
}