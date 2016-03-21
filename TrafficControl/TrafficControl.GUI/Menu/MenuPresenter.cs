using Android.App;
using Android.Views;

namespace TrafficControl.GUI.Menu
{
    public class MenuPresenter : IMenuPresenter
    {
        private Activity _contextActivity;
        public MenuPresenter(Activity contextActivity)
        {
            _contextActivity = contextActivity;
        }

        public bool OnCreateOptionsMenu(MenuInflater menuInflater, IMenu menu)
        {
            menuInflater.Inflate(Resource.Menu.main_menu, menu);
            return true;
        }

        public bool OnOptionsItemSelected(IMenuItem item)
        {
            var id = item.ItemId;
            switch (id)
            {
                case Resource.Id.Profile:
                    return OnMenuProfileClicked();
                case Resource.Id.Options:
                    return OnMenuOptionsClicked();
                case Resource.Id.About:
                    return OnMenuAboutClicked();
            }

            return false;
        }

        private bool OnMenuProfileClicked()
        {
            return true;
        }

        private bool OnMenuOptionsClicked()
        {
            if (_contextActivity.GetType() != typeof (OptionsActivity))
            {
                _contextActivity.StartActivity(typeof(OptionsActivity));
                return true;
            }
            return false;
        }

        private bool OnMenuAboutClicked()
        {
            return true;
        }
    }
}