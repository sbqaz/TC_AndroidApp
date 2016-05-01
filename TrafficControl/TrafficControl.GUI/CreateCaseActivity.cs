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
using TrafficControl.GUI.CreateCase;

namespace TrafficControl.GUI
{
    [Activity(Label = "Opret sag")]
    public class CreateCaseActivity : Activity, ICreateCaseView
    {
        private ICreateCasePresenter _presenter;
        private AutoCompleteTextView _installation;
        private AutoCompleteTextView _observedBy;
        private EditText _errorDescription;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CreateCase);

            _presenter = new CreateCasePresenter(this, ModelFactory.Instance.CreateCreateCaseModel());

            var installationAdapter = new ArrayAdapter<String>(this, Resource.Layout.SideMenuItem, _presenter.Installations);
            _installation = FindViewById<AutoCompleteTextView>(Resource.Id.create_case_installation);
            _installation.Adapter = installationAdapter;

            _observedBy = FindViewById<AutoCompleteTextView>(Resource.Id.create_case_installation);
            _observedBy.Adapter = installationAdapter;

            _installation = FindViewById<AutoCompleteTextView>(Resource.Id.create_case_installation);
            _installation.Adapter = installationAdapter;

            _errorDescription = FindViewById<EditText>(Resource.Id.create_case_errorDescription);

            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
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