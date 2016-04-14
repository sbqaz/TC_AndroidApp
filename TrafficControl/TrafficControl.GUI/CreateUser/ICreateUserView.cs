namespace TrafficControl.GUI.CreateUser
{
    public interface ICreateUserView
    {
        void ShowMissingInfoError();
        void SetEmailError();
        void SetPasswordError();
        void SetConfirmPasswordError();
        void SetNameError();
        void SetPhoneNumberError();
        void ConfirmPasswordNotMatchingError();
        void UserCreated();
        void ShowProgressDialog();
        void HideProgressDialog();
        void UserNotCreated();
    }
}