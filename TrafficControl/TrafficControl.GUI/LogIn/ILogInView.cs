﻿namespace TrafficControl.GUI.LogIn
{
    public interface ILogInView
    {
        void SetPasswordError();
        void SetEmailError();
        void ShowLogInErrorMsg();
        void HideLogInErrorMsg();
        void ShowProgressDialog();
        void HideProgressDialog();
        void NavigateToHome();
    }
}