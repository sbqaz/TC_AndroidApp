using TrafficControl.DAL.RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.BLL.Home
{
    public class UserPreference : IUserPreference
    {
        private User _currentUser;
        private ITCApi _api;

        //Update User from here!!
        public UserPreference(ITCApi api)
        {
            _api = api;
        }

        public void SetUserPreference()
        {
            _currentUser = _api.GetUser();
        }

        public string GetUserFirstName()
        {
            return _currentUser.FirstName;
        }

        public string GetUserLastName()
        {
            return _currentUser.LastName;
        }

        public string GetPhonenumber()
        {
            return _currentUser.Number;
        }

        public bool GetEmailNotification()
        {
            return _currentUser.EmailNotification;
        }

        public bool GetSmsNotification()
        {
            return _currentUser.SMSNotification;
        }

        public void SetFirstName(string newFirstName)
        {
            _currentUser.FirstName = newFirstName;
            UpdateCurrentUser();
        }

        public void SetLastName(string newLastName)
        {
            _currentUser.LastName = newLastName;
            UpdateCurrentUser();
        }

        public void SetPhonenumber(string newPhonenumber)
        {
            _currentUser.Number = newPhonenumber;
            UpdateCurrentUser();
        }

        public void SetNotifyEmail(bool newNotification)
        {
            _currentUser.EmailNotification = newNotification;
            UpdateCurrentUser();
        }

        public void SetNotifySms(bool newNotification)
        {
            _currentUser.SMSNotification = newNotification;
            UpdateCurrentUser();
        }

        private void UpdateCurrentUser()
        {
            //Update via api
            //_api.UpdateUser(_currentUser);
        }
    }
}