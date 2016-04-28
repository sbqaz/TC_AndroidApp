namespace TrafficControl.GUI.CreateUser
{
    public interface IChangePasswordView
    {
        void ShowMissingInfoError();
        void SetOldPasswordError();
        void SetNewPasswordError();
        void SetConfirmNewPasswordError();
        void ConfirmNewPasswordNotMatchingError();
        void ShowProgressDialog();
        void HideProgressDialog();
        void PasswordChanged();
        void PasswordNotChanged();
    }
}