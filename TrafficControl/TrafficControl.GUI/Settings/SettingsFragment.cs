using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Views;
using Android.Widget;
using TrafficControl.BLL;

namespace TrafficControl.GUI.Settings
{
    public class SettingsFragment : PreferenceFragment, ISharedPreferencesOnSharedPreferenceChangeListener, ISettingsView
    {
        private ISettingsPresenter _presenter;
        private Preference _createUserPreference;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AddPreferencesFromResource(Resource.Layout.SettingsFragment);

            _presenter = new SettingsPresenter(this, ModelFactory.Instance.CreateSettingsModel());
            _createUserPreference = FindPreference(GetString(Resource.String.settings_create_user));
            _createUserPreference.PreferenceClick += OnCreateUserClicked;
        }

        private void OnCreateUserClicked(object sender, Preference.PreferenceClickEventArgs e)
        {
            Toast.MakeText(Activity, "_CreateUser_", ToastLength.Long).Show();
            _presenter.CreateUser(); //This function does nothing right now!
        }

        public override void OnResume()
        {
            base.OnResume();
            PreferenceScreen.SharedPreferences.RegisterOnSharedPreferenceChangeListener(this);
        }

        public override void OnPause()
        {
            base.OnPause();
            PreferenceScreen.SharedPreferences.UnregisterOnSharedPreferenceChangeListener(this);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        public void OnSharedPreferenceChanged(ISharedPreferences sharedPreferences, string key)
        {
            if (key.Equals("switch_preference"))
            {
                Toast.MakeText(Activity, "Switched", ToastLength.Long).Show();
            }
        }
    }
}