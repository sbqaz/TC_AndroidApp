using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.Util;
using TrafficControl.BLL;
using TrafficControl.BLL.Home;
using TrafficControl.BLL.Observer;
using TrafficControl.GUI.Adapters;
using TrafficControl.GUI.Home;
using TrafficControl.GUI.Menu;
using Object = Java.Lang.Object;

namespace TrafficControl.GUI
{
    [Activity(Label = "Hjem")]
    public class HomeActivity : Activity, IHomeView
    {
        private IHomePresenter _presenter;
        private IMenuPresenter _menuPresenter;
        private ListView _myCasesList;
        private ListView _allCasesList;
        private CaseAdapter _myCaseAdapter;
        private CaseAdapter _allCaseAdapter;

        //List of cases should only be in model, do some fancy stuff with adapters!
         
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Home);

            _myCasesList = FindViewById<ListView>(Resource.Id.MyCasesListing);
            _allCasesList = FindViewById<ListView>(Resource.Id.AllCasesListing);
            _menuPresenter = new MenuPresenter(this);
            _presenter = new HomePresenter(this, ModelFactory.Instance.CreateHomeModel());
            
            _myCaseAdapter = new CaseAdapter(this, _presenter.GetCases());
            _myCasesList.Adapter = _myCaseAdapter;
            _myCasesList.ItemClick += CaseItemClicked;

            _allCaseAdapter = new CaseAdapter(this, _presenter.GetCases());
            _allCasesList.Adapter = _allCaseAdapter;
            _allCasesList.ItemClick += CaseItemClicked;
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            return _menuPresenter.OnCreateOptionsMenu(new MenuInflater(this),menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            return _menuPresenter.OnOptionsItemSelected(item);
        }
        
        private void CaseItemClicked(object sender, AdapterView.ItemClickEventArgs e)
        {
            _presenter.CaseItemClicked(this, sender, e);
        }

        protected override void OnDestroy()
        {
            _presenter.OnDestroy();
            base.OnDestroy();
        }

        public void UpdateCaseView()
        {
            RunOnUiThread(() => _myCaseAdapter.NotifyDataSetChanged());
            RunOnUiThread(() => _allCaseAdapter.NotifyDataSetChanged());
        }

        public void NavigateToOptions()
        {
            StartActivity(typeof(OptionsActivity));
        }
    }
}