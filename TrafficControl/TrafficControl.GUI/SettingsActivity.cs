using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using TrafficControl.GUI.Settings;

namespace TrafficControl.GUI
{
    [Activity(Label = "Indstillinger")]
    public class SettingsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Settings);

            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
            
            if (savedInstanceState == null)
            {
                //Fragment manager / transaction
                var fragTx = this.FragmentManager.BeginTransaction();
                SettingsFragment settingsFragment = new SettingsFragment();

                fragTx.Add(Resource.Id.SettingsContentFrame, settingsFragment);
                fragTx.Commit();
            }
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