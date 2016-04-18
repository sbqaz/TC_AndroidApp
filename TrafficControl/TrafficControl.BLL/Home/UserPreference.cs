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

        public string GetUserName()
        {
            return _currentUser.FirstName + " " + _currentUser.LastName;
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
    }
}