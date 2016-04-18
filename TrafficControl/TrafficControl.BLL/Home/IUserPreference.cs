namespace TrafficControl.BLL.Home
{
    public interface IUserPreference
    {
        string GetUserName();
        string GetPhonenumber();
        bool GetEmailNotification();
        bool GetSmsNotification();
    }
}