﻿using Android.App;
using Android.OS;
using TrafficControl.GUI.Home;

namespace TrafficControl.GUI
{
    [Activity(Label = "Hjem")]
    public class HomeActivity : MenuActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            
            AddTab("Mine sager", new MyCasesFragment());
            AddTab("Seneste sager", new AllCasesFragment());
        }

        private void AddTab(string tabText, Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            
            // must set event handler before adding tab
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.ContentFrame);
                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);
                e.FragmentTransaction.Add(Resource.Id.ContentFrame, view);
            };
            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e) {
                e.FragmentTransaction.Remove(view);
            };

            this.ActionBar.AddTab(tab);
        }
    }
}