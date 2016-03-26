using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using TrafficControl.BLL;
using TrafficControl.GUI.Menu;
using TrafficControl.GUI.Settings;

namespace TrafficControl.GUI
{
    [Activity(Label = "Indstillinger")]
    public class SettingsActivity : Activity
    {
        private IMenuPresenter _menuPresenter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Settings);
            
            _menuPresenter = new MenuPresenter(this);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            return _menuPresenter.OnCreateOptionsMenu(new MenuInflater(this), menu);
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
    }
}