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
using TrafficControl.GUI.Lyskryds;
using Object = Java.Lang.Object;

namespace TrafficControl.GUI
{
    [Activity(Label = "Lyskryds")]
       
    public class TrafficLightOverviewActivity : MenuActivity, ITrafficLightOverviewView
    {
            private Spinner _userTypeSpinner;
            private Button _sortCases;
            private ITrafficViewOverViewPresenter _presenter;
            private string _typeSelected;

        protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.TrafficLights);

                _sortCases = FindViewById<Button>(Resource.Id.SortTrafficLightBtn);
                _presenter = new TrafficLightOverviewPresenter(this, ModelFactory.Instance.CreateLyskrydsModel());

                _sortCases.Click += SortTrafficLightOnClick;

            _userTypeSpinner = FindViewById<Spinner>(Resource.Id.SortTrafficLightSpinner);
                _userTypeSpinner.ItemSelected += spinner_ItemSelected;
                var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.SortCases, Resource.Layout.SortTrafficLightSpinner);

            adapter.SetDropDownViewResource(Resource.Layout.SortTrafficLightDropDownItem);
            _userTypeSpinner.Adapter = adapter;

            if (savedInstanceState == null)
            {
                var fragTx = this.FragmentManager.BeginTransaction();
                var trafficLightFragment = new AllTrafficLightFragment();
                fragTx.Add(Resource.Id.TrafficLightContentFrame, trafficLightFragment);
                fragTx.Commit();
            }

            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);

        }

        private void SortTrafficLightOnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            _typeSelected = (string)_userTypeSpinner.GetItemAtPosition(e.Position);
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