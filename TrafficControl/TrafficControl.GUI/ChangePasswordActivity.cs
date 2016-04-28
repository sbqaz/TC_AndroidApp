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
using TrafficControl.GUI.CreateUser;

namespace TrafficControl.GUI
{
    [Activity(Label = "Skift adgangskode")]
    public class ChangePasswordActivity : Activity, IChangePasswordView
    {
        private EditText _oldPassword;
        private EditText _newPassword;
        private EditText _confirmNewPassword;
        private Button _changePasswordButton;
        private IChangePasswordPresenter _presenter;
        private ProgressDialog _progressDialog;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ChangePassword);

            _oldPassword = FindViewById<EditText>(Resource.Id.OldPassword);
            _newPassword = FindViewById<EditText>(Resource.Id.NewPassword);
            _confirmNewPassword = FindViewById<EditText>(Resource.Id.ConfirmNewPassword);
            _changePasswordButton = FindViewById<Button>(Resource.Id.ChangePasswordBtn);

            _presenter = new ChangePasswordPresenter(this, ModelFactory.Instance.CreateChangePasswordModel());
            _changePasswordButton.Click += OnChangePasswordButtonClicked;

            _progressDialog = new ProgressDialog(this);
            _progressDialog.SetMessage("Opretter ny bruger...");

            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
        }

        private void OnChangePasswordButtonClicked(object sender, EventArgs e)
        {
            _presenter.ChangePassword(_oldPassword.Text, _newPassword.Text, _confirmNewPassword.Text);
        }

        public override bool OnMenuItemSelected(int featureId, IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                Finish();
            }
            return base.OnMenuItemSelected(featureId, item);
        }

        public void ShowMissingInfoError()
        {
            string toast = "Alle felter skal udfyldes";
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        public void SetOldPasswordError()
        {
            _oldPassword.RequestFocus();
            _oldPassword.SetError("Gammel adgangskode skal udfyldes", null);
        }

        public void SetNewPasswordError()
        {
            _newPassword.RequestFocus();
            _newPassword.SetError("Ny adgangskode skal udfyldes", null);
        }

        public void SetConfirmNewPasswordError()
        {
            _confirmNewPassword.RequestFocus();
            _confirmNewPassword.SetError("Bekræft ny adgangskode skal udfyldes", null);
        }

        public void ConfirmNewPasswordNotMatchingError()
        {
            _confirmNewPassword.RequestFocus();
            _confirmNewPassword.SetError("Passer ikke overens med ny adgangskode", null);
        }

        public void ShowProgressDialog()
        {
            _progressDialog.Show();
        }

        public void HideProgressDialog()
        {
            _progressDialog.Hide();
        }

        public void PasswordChanged()
        {
            string toast = "Adgangskode ændret";
            Toast.MakeText(this, toast, ToastLength.Short).Show();
            Finish();
        }

        public void PasswordNotChanged()
        {
            string toast = "Adgangskode kunne ikke ændres, tjek forbindelsen";
            Toast.MakeText(this, toast, ToastLength.Short).Show();
        }
    }
}