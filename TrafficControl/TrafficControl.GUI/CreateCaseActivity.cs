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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CreateCase);

            _presenter = new CreateCasePresenter(this, ModelFactory.Instance.CreateCreateCaseModel());

            ArrayAdapter<String> installationAdapter = new ArrayAdapter<String>(this, Resource.Layout.SideMenuItem, _presenter.Installations);
            AutoCompleteTextView installation = FindViewById<AutoCompleteTextView>(Resource.Id.create_case_installation);
            installation.Threshold = 1;
            installation.Adapter = installationAdapter;
            
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