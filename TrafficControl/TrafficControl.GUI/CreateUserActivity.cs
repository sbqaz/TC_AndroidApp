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
using Object = Java.Lang.Object;

namespace TrafficControl.GUI
{
    [Activity(Label = "Opret ny bruger")]
    public class CreateUserActivity : Activity, ICreateUserView
    {
        private EditText _email;
        private EditText _password;
        private EditText _confirmPassword;
        private EditText _firstName;
        private EditText _lastName;
        private EditText _phoneNumber;
        private Spinner _userTypeSpinner;
        private Button _createUser;
        private ICreateUserPresenter _presenter;
        private string _typeSelected;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CreateUser);

            _email = FindViewById<EditText>(Resource.Id.CreateEmailInput);
            _password = FindViewById<EditText>(Resource.Id.PasswordCreate);
            _confirmPassword = FindViewById<EditText>(Resource.Id.ConfirmPasswordCreate);
            _firstName = FindViewById<EditText>(Resource.Id.CreateFirstNameInput);
            _lastName = FindViewById<EditText>(Resource.Id.CreateLastNameInput);
            _phoneNumber = FindViewById<EditText>(Resource.Id.CreatePhonenumberInput);
            _createUser = FindViewById<Button>(Resource.Id.CreateUserBtn);
            _presenter = new CreateUserPresenter(this, ModelFactory.Instance.CreateCreateUserModel());

            _createUser.Click += CreateUserOnClick;

            _userTypeSpinner = FindViewById<Spinner>(Resource.Id.UserTypeSpinner);
            _userTypeSpinner.ItemSelected += spinner_ItemSelected;
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.UserTypes, Resource.Layout.UserTypeSpinnerItem);

            adapter.SetDropDownViewResource(Resource.Layout.UserTypeDropDownItem);
            _userTypeSpinner.Adapter = adapter;

            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
        }

        private void CreateUserOnClick(object sender, EventArgs eventArgs)
        {
            _presenter.OnCreateUserClick(_email.Text, _password.Text, _confirmPassword.Text, _firstName.Text + " " + _lastName.Text, _phoneNumber.Text, _typeSelected);
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            _typeSelected = (string) _userTypeSpinner.GetItemAtPosition(e.Position);
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

        public void SetEmailError()
        {
            _email.RequestFocus();
            _email.SetError("Email skal udfyldes", null);
        }

        public void SetPasswordError()
        {
            _password.RequestFocus();
            _password.SetError("Kodeord skal udfyldes", null);
        }

        public void SetConfirmPasswordError()
        {
            _confirmPassword.RequestFocus();
            _confirmPassword.SetError("Bekræft kodeord skal udfyldes", null);
        }

        public void SetNameError()
        {
            _firstName.RequestFocus();
            _firstName.SetError("Fornavn skal udfyldes", null);
        }

        public void SetPhoneNumberError()
        {
            _phoneNumber.RequestFocus();
            _phoneNumber.SetError("Kodeord skal udfyldes", null);
        }

        public void ConfirmPasswordNotMatchingError()
        {
            _confirmPassword.RequestFocus();
            _confirmPassword.SetError("Passer ikker overens med kodeord", null);
        }

        public void UserCreated()
        {
            string toast = "Bruger oprettet";
            Toast.MakeText(this, toast, ToastLength.Long).Show();
            Finish();
        }
    }
}