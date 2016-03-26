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
using TrafficControl.GUI.Settings;
using Object = Java.Lang.Object;

namespace TrafficControl.GUI
{
    [Activity(Label = "Hjem")]
    public class HomeActivity : Activity, IHomeView
    {
        private IHomePresenter _presenter;
        private IMenuPresenter _menuPresenter;
        private CaseAdapter _myCaseAdapter;
        private CaseAdapter _allCaseAdapter;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Home);

            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            
             _menuPresenter = new MenuPresenter(this);
            _presenter = new HomePresenter(this, ModelFactory.Instance.CreateHomeModel());
            
            _myCaseAdapter = new CaseAdapter(this, _presenter.GetCases());
            _allCaseAdapter = new CaseAdapter(this, _presenter.GetCases());
            
            AddTab("Mine sager", new CasesFragment(_myCaseAdapter, _presenter));
            AddTab("Seneste sager", new CasesFragment(_allCaseAdapter, _presenter));
        }

        private void AddTab(string tabText, Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);

            // must set event handler before adding tab
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.HomeContentFrame);
                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);
                e.FragmentTransaction.Add(Resource.Id.HomeContentFrame, view);
            };
            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e) {
                e.FragmentTransaction.Remove(view);
            };

            this.ActionBar.AddTab(tab);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            return _menuPresenter.OnCreateOptionsMenu(new MenuInflater(this),menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            return _menuPresenter.OnOptionsItemSelected(item);
        }

        protected override void OnStop()
        {
            base.OnStop();
            _menuPresenter.HideLeftMenu();
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
    }
}