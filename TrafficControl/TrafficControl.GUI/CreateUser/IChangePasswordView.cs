namespace TrafficControl.GUI.CreateUser
{
    public interface IChangePasswordView
    {
        void ShowMissingInfoError();
        void SetOldPasswordError();
        void SetNewPasswordError();
        void SetConfirmNewPasswordError();
    }
}