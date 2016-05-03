namespace TrafficControl.BLL.Home
{
    public interface IUserPreference
    {
        void SetUserPreference();
        string GetUserFirstName();
        string GetUserLastName();
        string GetPhonenumber();
        bool GetEmailNotification();
        bool GetSmsNotification();
        void SetFirstName(string newFirstName);
        void SetLastName(string newLastName);
        void SetPhonenumber(string newPhonenumber);
        void SetNotifyEmail(bool newNotification);
        void SetNotifySms(bool newNotification);
    }
}