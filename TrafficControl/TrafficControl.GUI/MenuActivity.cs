using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using TrafficControl.GUI.Menu;

namespace TrafficControl.GUI
{
    public class MenuActivity : Activity, IMenuView
    {
        private IMenuPresenter _presenter;

        private DrawerLayout _drawerLayout;
        private ArrayAdapter _leftAdapter;
        private ListView _leftDrawer;

        protected FrameLayout ContentFrameLayout { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MenuActivityLayout);

            _presenter = new MenuPresenter(this);

            ContentFrameLayout = FindViewById<FrameLayout>(Resource.Id.ContentFrame);

            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.OptionsDrawer);
            _leftDrawer = FindViewById<ListView>(Resource.Id.LeftListView);

            _leftAdapter = new ArrayAdapter(this, Resource.Layout.SideMenuItem, _presenter.GetMenuItems());
            _leftDrawer.Adapter = _leftAdapter;
            _leftDrawer.ItemClick += LeftDrawerItemClicked;

            ActionBar.SetDisplayHomeAsUpEnabled(false);
            ActionBar.SetHomeButtonEnabled(true);
            
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            return _presenter.OnCreateOptionsMenu(new MenuInflater(this), menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            return _presenter.OnOptionsItemSelected(item);
        }

        protected override void OnStop()
        {
            base.OnStop();
            _presenter.OnStop();
        }

        private void LeftDrawerItemClicked(object sender, AdapterView.ItemClickEventArgs e)
        {
            _presenter.LeftMenuItemClicked(e.Position);
        }

        public void HideLeftMenu()
        {
            if (_leftDrawer.IsShown)
            {
                _drawerLayout.CloseDrawer(FindViewById<ListView>(Resource.Id.LeftListView));
            }
        }

        public void OnHomeClicked()
        {
            if (GetType() != typeof(HomeActivity))
            {
                var nextActivity = new Intent(this, typeof(HomeActivity));
                nextActivity.AddFlags(ActivityFlags.ReorderToFront);
                StartActivity(nextActivity);
            }
        }

        public bool OnSettingsClicked()
        {
            if (GetType() != typeof(SettingsActivity))
            {
                var nextActivity = new Intent(this, typeof(SettingsActivity));
                nextActivity.AddFlags(ActivityFlags.ReorderToFront);
                StartActivity(nextActivity);
                return true;
            }
            return false;
        }
        public bool OnDrawerBtnClicked()
        {
            if (!_leftDrawer.IsShown)
            {
                _drawerLayout.OpenDrawer(_leftDrawer);
            }
            else
            {
                _drawerLayout.CloseDrawer(_leftDrawer);

            }
            return true;
        }

        public bool OnLogOutClicked()
        {
            StartActivity(typeof(LogInActivity));
            FinishAffinity();
            return true;
        }

        public void HideLeftDrawer()
        {
            if (_leftDrawer.IsShown)
            {
                _drawerLayout.CloseDrawer(_leftDrawer);
            }
        }

        public void OnTrafficLightClicked()
        {
            if (GetType() != typeof(TrafficLightOverviewActivity))
            {
                var nextActivity = new Intent(this, typeof(TrafficLightOverviewActivity));
                nextActivity.AddFlags(ActivityFlags.ReorderToFront);
                StartActivity(nextActivity);
            }
        }

        public bool OnMapClicked()
        {
            Toast.MakeText(this, "Loading map...", ToastLength.Short).Show();
            if (GetType() != typeof(MapActivity))
            {
                var nextActivity = new Intent(this, typeof(MapActivity));
                nextActivity.AddFlags(ActivityFlags.ReorderToFront);
                StartActivity(nextActivity);
                return true;
            }
            return false;
        }
    }
}