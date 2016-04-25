namespace TrafficControl.GUI.Settings
{
    public interface ISettingsPresenter
    {
        void CreateUser();
        void ChangePassword();
        void FirstNameChanged(string newFirstName);
        void LastNameChanged(string getString);
        void PhonenumberChanged(string getString);
        void NotifyEmailChanged(bool getBoolean);
        void NotifySmsChanged(bool getBoolean);
    }
}