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

namespace TrafficControl.GUI
{
    [Activity(Label = "Opret ny bruger")]
    public class CreateUserActivity : Activity
    {
        private EditText _email;
        private EditText _firstName;
        private EditText _lastName;
        private EditText _phoneNumber;
        private Spinner _userTypeSpinner;
        private Button _createUser;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CreateUser);

            _email = FindViewById<EditText>(Resource.Id.CreateEmailInput);
            _firstName = FindViewById<EditText>(Resource.Id.CreateFirstNameInput);
            _lastName = FindViewById<EditText>(Resource.Id.CreateLastNameInput);
            _phoneNumber = FindViewById<EditText>(Resource.Id.CreatePhonenumberInput);
            _createUser = FindViewById<Button>(Resource.Id.CreateUserBtn);

            _userTypeSpinner = FindViewById<Spinner>(Resource.Id.UserTypeSpinner);
            _userTypeSpinner.ItemSelected += spinner_ItemSelected;
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.UserTypes, Resource.Layout.UserTypeSpinnerItem);

            adapter.SetDropDownViewResource(Resource.Layout.UserTypeDropDownItem);
            _userTypeSpinner.Adapter = adapter;

            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            string toast = string.Format("Type: {0}", _userTypeSpinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        public override bool OnMenuItemSelected(int featureId, IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                Finish();
            }
            return base.OnMenuItemSelected(featureId, item);
        }
    }
}