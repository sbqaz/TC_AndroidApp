using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TrafficControl.BLL;
using TrafficControl.BLL.LogIn;
using TrafficControl.GUI.LogIn;

namespace TrafficControl.GUI
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true)]
    public class LogInActivity : Activity, ILogInView
    {
        private ILogInPresenter _presenter;
        private EditText _email;
        private EditText _password;
        private Button _logInBtn;
        private TextView _logInErrorMsg;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.LogIn);

            _email = FindViewById<EditText>(Resource.Id.EmailInput);
            _password = FindViewById<EditText>(Resource.Id.PasswordInput);
            _logInBtn = FindViewById<Button>(Resource.Id.MyButton);
            _logInErrorMsg = FindViewById<TextView>(Resource.Id.LogInErrorMsg);
            _presenter = new LogInPresenter(this, ModelFactory.Instance.CreateLogInModel());

            _logInBtn.Click += OnLogInBtnClicked;

        }

        private void OnLogInBtnClicked(object sender, EventArgs e)
        {
            _presenter.LogInCredentials(_email.Text, _password.Text);
        }

        protected override void OnDestroy()
        {
            _presenter.OnDestroy();
            base.OnDestroy();
        }

        public void SetPasswordError()
        {
            _password.RequestFocus();
            _password.SetError("Password cannot be empty", null);
        }

        public void SetEmailError()
        {
            _email.RequestFocus();
            _email.SetError("Email cannot be empty", null);
        }

        public void ShowLogInErrorMsg()
        {
            _logInErrorMsg.Visibility = ViewStates.Visible;
        }

        public void HideLogInErrorMsg()
        {
            _logInErrorMsg.Visibility = ViewStates.Invisible;
        }

        public void NavigateToHome()
        {
            StartActivity(typeof(HomeActivity));
        }
    }
}