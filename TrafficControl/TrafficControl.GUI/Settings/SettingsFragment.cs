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
        private Preference _changePassword;
        

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AddPreferencesFromResource(Resource.Layout.SettingsFragment);

            _presenter = new SettingsPresenter(this, ModelFactory.Instance.CreateSettingsModel(), ModelFactory.Instance.CreateUserPreference());
            _createUserPreference = FindPreference(GetString(Resource.String.settings_create_user));
            _changePassword = FindPreference(GetString(Resource.String.settings_user_password));
            _createUserPreference.PreferenceClick += OnCreateUserClicked;
            _changePassword.PreferenceClick += OnChangePasswordClicked;
        }

        private void OnChangePasswordClicked(object sender, Preference.PreferenceClickEventArgs e)
        {
            _presenter.ChangePassword();
        }

        private void OnCreateUserClicked(object sender, Preference.PreferenceClickEventArgs e)
        {
            _presenter.CreateUser();
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
            ISharedPreferences settings = PreferenceManager.GetDefaultSharedPreferences(Activity);
            if (key.Equals(GetString(Resource.String.settings_user_name)))
            {
                _presenter.FirstNameChanged(settings.GetString(GetString(Resource.String.settings_user_name), " "));
            }
            else if (key.Equals(GetString(Resource.String.settings_user_lastname)))
            {
                _presenter.LastNameChanged(settings.GetString(GetString(Resource.String.settings_user_lastname), " "));
            }
            else if (key.Equals(GetString(Resource.String.settings_user_phonenumber)))
            {
                _presenter.PhonenumberChanged(settings.GetString(GetString(Resource.String.settings_user_phonenumber), " "));
            }
            else if (key.Equals(GetString(Resource.String.settings_notify_email)))
            {
                _presenter.NotifyEmailChanged(settings.GetBoolean(GetString(Resource.String.settings_notify_email), false));
            }
            else if (key.Equals(GetString(Resource.String.settings_notify_sms)))
            {
                _presenter.NotifySmsChanged(settings.GetBoolean(GetString(Resource.String.settings_notify_sms), false));
            }
        }
        
        public void NavigateToCreateUser()
        {
            if (GetType() != typeof(CreateUserActivity))
            {
                var nextActivity = new Intent(Activity, typeof(CreateUserActivity));
                nextActivity.AddFlags(ActivityFlags.ReorderToFront);
                StartActivity(nextActivity);
            }
        }

        public void NavigateToChangePassword()
        {
            //if (GetType() != typeof(CreateUserActivity))
            //{
            //    var nextActivity = new Intent(Activity, typeof(CreateUserActivity));
            //    nextActivity.AddFlags(ActivityFlags.ReorderToFront);
            //    StartActivity(nextActivity);
            //}
        }
    }
}