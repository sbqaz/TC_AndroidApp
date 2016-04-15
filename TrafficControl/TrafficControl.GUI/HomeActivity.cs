using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
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

            SetUserPreferences();
        }

        private void SetUserPreferences()
        {
            //Set preference text to summary instead of preference_value
            ISharedPreferences settings = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = settings.Edit();
            editor.PutString("test_preference", "PRESET Preference");
            editor.Apply();
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