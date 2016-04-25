using TrafficControl.BLL.Home;
using TrafficControl.BLL.Settings;

namespace TrafficControl.GUI.Settings
{
    public class SettingsPresenter : ISettingsPresenter
    {
        private ISettingsView _settingsView;
        private ISettingsModel _settingsModel;
        private IUserPreference _userPreference;

        public SettingsPresenter(ISettingsView settingsView, ISettingsModel settingsModel, IUserPreference userPreference)
        {
            _settingsView = settingsView;
            _settingsModel = settingsModel;
            _userPreference = userPreference;
        }

        public void CreateUser()
        {
            _settingsView.NavigateToCreateUser();
        }

        public void ChangePassword()
        {
            _settingsView.NavigateToChangePassword();
        }

        public void FirstNameChanged(string newFirstName)
        {
            _userPreference.SetFirstName(newFirstName);
        }

        public void LastNameChanged(string newLastName)
        {
            _userPreference.SetLastName(newLastName);
        }

        public void PhonenumberChanged(string newPhonenumber)
        {
            _userPreference.SetPhonenumber(newPhonenumber);
        }

        public void NotifyEmailChanged(bool newNotification)
        {
            _userPreference.SetNotifyEmail(newNotification);
        }

        public void NotifySmsChanged(bool newNotification)
        {
            _userPreference.SetNotifySms(newNotification);
        }
    }
}