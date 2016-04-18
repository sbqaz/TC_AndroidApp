namespace TrafficControl.BLL.Home
{
    public interface IUserPreference
    {
        void SetUserPreference();
        string GetUserName();
        string GetPhonenumber();
        bool GetEmailNotification();
        bool GetSmsNotification();
    }
}