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
    [Activity(Label = "Skift kodeord")]
    public class ChangePasswordActivity : Activity, IChangePasswordView
    {
        private EditText _oldPassword;
        private EditText _newPassword;
        private EditText _confirmNewPassword;
        private Button _changePasswordButton;
        private IChangePasswordPresenter _presenter;

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
            throw new NotImplementedException();
        }

        public void SetOldPasswordError()
        {
            throw new NotImplementedException();
        }

        public void SetNewPasswordError()
        {
            throw new NotImplementedException();
        }

        public void SetConfirmNewPasswordError()
        {
            throw new NotImplementedException();
        }
    }
}