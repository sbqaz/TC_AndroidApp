using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using TrafficControl.BLL;
using TrafficControl.GUI.Menu;
using TrafficControl.GUI.Options;

namespace TrafficControl.GUI
{
    [Activity(Label = "Indstillinger")]
    public class OptionsActivity : Activity, IOptionsView
    {
        private IOptionsPresenter _presenter;
        private IMenuPresenter _menuPresenter;

        //For testing
        private DrawerLayout _drawerLayout;
        private List<string> _leftItems = new List<string>();
        private ArrayAdapter _leftAdapter;
        private ListView _leftDrawer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Options);

            //For testing
            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.OptionsDrawer);
            _leftDrawer = FindViewById<ListView>(Resource.Id.LeftListView);

            _leftItems.Add("First");
            _leftItems.Add("Second");
            _leftItems.Add("Third");
            _leftAdapter = new ArrayAdapter(this, Resource.Layout.SideMenuItem, _leftItems);
            _leftDrawer.Adapter = _leftAdapter;


            _menuPresenter = new MenuPresenter(this);
            _presenter = new OptionsPresenter(this, ModelFactory.Instance.CreateOptionsModel());
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            return _menuPresenter.OnCreateOptionsMenu(new MenuInflater(this), menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            return _menuPresenter.OnOptionsItemSelected(item);
        }
    }
}