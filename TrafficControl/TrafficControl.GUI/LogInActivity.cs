using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Views;
using Android.Widget;
using TrafficControl.BLL;
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
        private CheckBox _rememberChkBox;

        private ProgressDialog _progressDialog;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.LogIn);

            _email = FindViewById<EditText>(Resource.Id.EmailInput);
            _password = FindViewById<EditText>(Resource.Id.PasswordInput);
            _logInBtn = FindViewById<Button>(Resource.Id.MyButton);
            _logInErrorMsg = FindViewById<TextView>(Resource.Id.LogInErrorMsg);
            _rememberChkBox = FindViewById<CheckBox>(Resource.Id.rememberMeChkBox);
            _presenter = new LogInPresenter(this, ModelFactory.Instance.CreateLogInModel());

            _progressDialog = new ProgressDialog(this);
            _progressDialog.SetMessage("Logger ind...");
            
            ISharedPreferences settings = Application.Context.GetSharedPreferences("TCInfo", FileCreationMode.Private);
            string email = settings.GetString(GetString(Resource.String.login_email), String.Empty);
            string password = settings.GetString(GetString(Resource.String.login_password), String.Empty);

            if (email != String.Empty || password != String.Empty)
            {
                _email.Text = email;
                _password.Text = password;
                _rememberChkBox.Checked = true;
            }

            _logInBtn.Click += OnLogInBtnClicked;

        }

        private void OnLogInBtnClicked(object sender, EventArgs e)
        {
            _presenter.LogInCredentialsAsync(_email.Text, _password.Text);

            ISharedPreferences settings = Application.Context.GetSharedPreferences("TCInfo", FileCreationMode.Private);
            ISharedPreferencesEditor editor = settings.Edit();

            if (_rememberChkBox.Checked)
            {
                editor.PutString(GetString(Resource.String.login_email), _email.Text);
                editor.PutString(GetString(Resource.String.login_password), _password.Text);
                editor.Commit();
            }
            else
            {
                editor.PutString(GetString(Resource.String.login_email), String.Empty);
                editor.PutString(GetString(Resource.String.login_password), String.Empty);
                editor.Commit();
            }
        }

        protected override void OnDestroy()
        {
            _presenter.OnDestroy();
            base.OnDestroy();
        }

        public void SetPasswordError()
        {
            _password.RequestFocus();
            _password.SetError("Adgangskode må ikke være tom", null);
        }

        public void SetEmailError()
        {
            _email.RequestFocus();
            _email.SetError("Email må ikke være tom", null);
        }

        public void ShowProgressDialog()
        {
            _progressDialog.Show();
        }

        public void HideProgressDialog()
        {
            _progressDialog.Hide();
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