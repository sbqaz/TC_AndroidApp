using System.Threading.Tasks;
using TrafficControl.DAL.RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.BLL.Home
{
    public class UserPreference : IUserPreference
    {
        private User _currentUser;
        private ITCApi _api;
        
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
            if(_currentUser.FirstName != null)
                return _currentUser.FirstName;
            return "_NO_NAME_";
        }

        public string GetUserLastName()
        {
            if(_currentUser.LastName != null)
                return _currentUser.LastName;
            return "_NO_NAME_";
        }

        public string GetPhonenumber()
        {
            if(_currentUser.Number != null)
                return _currentUser.Number;
            return "_NO_PHONENUMBER_";
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
            Task.Factory.StartNew(() => _api.UpdateUser(_currentUser));
            //Update via api
            //_api.UpdateUser(_currentUser);
        }
    }
}