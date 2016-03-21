using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using Java.Util;
using TrafficControl.BLL;
using TrafficControl.BLL.Home;
using TrafficControl.BLL.Observer;
using TrafficControl.GUI.Adapters;
using TrafficControl.GUI.Home;
using Object = Java.Lang.Object;

namespace TrafficControl.GUI
{
    [Activity(Label = "Home")]
    public class HomeActivity : Activity, IHomeView
    {
        private IHomePresenter _presenter;
        private ListView _myCasesList;
        private ListView _allCasesList;
        private CaseAdapter _myCaseAdapter;
        private CaseAdapter _allCaseAdapter;

        //List of cases should only be in model, do some fancy stuff with adapters!
        private List<Case> _cases;
         
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Home);
            
            _myCasesList = FindViewById<ListView>(Resource.Id.MyCasesListing);
            _allCasesList = FindViewById<ListView>(Resource.Id.AllCasesListing);
            
            InitCases();
            _myCaseAdapter = new CaseAdapter(this, _cases); //Get array from model via presenter
            _myCasesList.Adapter = _myCaseAdapter;
            _myCasesList.ItemClick += CaseItemClicked;

            _allCaseAdapter = new CaseAdapter(this, _cases);
            _allCasesList.Adapter = _allCaseAdapter;
            _allCasesList.ItemClick += CaseItemClicked;

            _presenter = new HomePresenter(this, new ModelFactory().CreateHomeModel());
        }

        //Put functionallity inside Presenter!
        private void CaseItemClicked(object sender, AdapterView.ItemClickEventArgs e)
        {
            string text = string.Format("Casename: {0}\n" +
                                        "Case Id: {1}", _cases[e.Position].Name, _cases[e.Position].Id);

            new AlertDialog.Builder(this).SetPositiveButton("Ok", (msender, args) => { })
                                                            .SetMessage(text)
                                                            .SetTitle("Case")
                                                            .Show();
        }

        private void InitCases()
        {
            _cases = new List<Case>();
        }

        protected override void OnDestroy()
        {
            _presenter.OnDestroy();
            base.OnDestroy();
        }

        public void AddCase(Case newCase)
        {
            //Redundant add call if view has reference to array in model
            _cases.Add(newCase);
            RunOnUiThread(() => _myCaseAdapter.NotifyDataSetChanged());
            RunOnUiThread(() => _allCaseAdapter.NotifyDataSetChanged());
        }
    }
}