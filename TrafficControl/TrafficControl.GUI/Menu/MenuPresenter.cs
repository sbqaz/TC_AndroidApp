﻿using Android.App;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;

namespace TrafficControl.GUI.Menu
{
    public class MenuPresenter : IMenuPresenter
    {
        private Activity _contextActivity;

        private DrawerLayout _drawerLayout;
        private string[] _leftItems = { "Hjem", "First", "Second", "Indstillinger" };
        private ArrayAdapter _leftAdapter;
        private ListView _leftDrawer;

        public MenuPresenter(Activity contextActivity)
        {
            _contextActivity = contextActivity;

            _drawerLayout = _contextActivity.FindViewById<DrawerLayout>(Resource.Id.OptionsDrawer);
            _leftDrawer = _contextActivity.FindViewById<ListView>(Resource.Id.LeftListView);

            _leftAdapter = new ArrayAdapter(_contextActivity, Resource.Layout.SideMenuItem, _leftItems);
            _leftDrawer.Adapter = _leftAdapter;
            _leftDrawer.ItemClick += LeftDrawerItemClicked;

            _contextActivity.ActionBar.SetDisplayHomeAsUpEnabled(false);
            _contextActivity.ActionBar.SetHomeButtonEnabled(true);
        }

        private void LeftDrawerItemClicked(object sender, AdapterView.ItemClickEventArgs e)
        {
            switch (_leftItems[e.Position])
            {
                case "Hjem":
                    OnHomeClicked();
                    break;
                case "First":
                    break;
                case "Second":
                    break;
                case "Indstillinger":
                    OnOptionsClicked();
                    break;
            }
        }

        //Duplicated activities
        private void OnHomeClicked()
        {
            if (_contextActivity.GetType() != typeof(HomeActivity))
            {
                _contextActivity.StartActivity(typeof(HomeActivity));
            }
        }

        public bool OnCreateOptionsMenu(MenuInflater menuInflater, IMenu menu)
        {
            menuInflater.Inflate(Resource.Menu.main_menu, menu);
            return true;
        }

        public bool OnOptionsItemSelected(IMenuItem item)
        {
            var id = item.ItemId;
            switch (id)
            {
                case Android.Resource.Id.Home:
                    return OnDrawerBtnClicked();
                case Resource.Id.Menu_Options:
                    return OnOptionsClicked();
                case Resource.Id.Menu_About:
                    return OnAboutClicked();
                case Resource.Id.Menu_LogOut:
                    return OnLogOutClicked();

            }

            return false;
        }

        private bool OnDrawerBtnClicked()
        {
            _drawerLayout.OpenDrawer(_contextActivity.FindViewById<ListView>(Resource.Id.LeftListView));
            return true;
        }

        private bool OnLogOutClicked()
        {
            _contextActivity.StartActivity(typeof(LogInActivity));
            _contextActivity.FinishAffinity();
            return true;
        }

        private bool OnOptionsClicked()
        {
            if (_contextActivity.GetType() != typeof (OptionsActivity))
            {
                _contextActivity.StartActivity(typeof(OptionsActivity));
                return true;
            }
            return false;
        }

        private bool OnAboutClicked()
        {
            return true;
        }
    }
}