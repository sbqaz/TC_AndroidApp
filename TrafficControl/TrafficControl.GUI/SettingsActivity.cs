using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using TrafficControl.BLL;
using TrafficControl.GUI.Menu;
using TrafficControl.GUI.Settings;

namespace TrafficControl.GUI
{
    [Activity(Label = "Indstillinger")]
    public class SettingsActivity : MenuActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            //Fragment manager / transaction
            var fragTx = this.FragmentManager.BeginTransaction();
            var settingsFragment = new SettingsFragment();
            fragTx.Add(Resource.Id.ContentFrame, settingsFragment);
            fragTx.Commit();
        }
    }
}