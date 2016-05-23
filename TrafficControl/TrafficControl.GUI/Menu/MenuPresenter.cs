using Android.Views;

namespace TrafficControl.GUI.Menu
{
    public class MenuPresenter : IMenuPresenter
    {
        private readonly IMenuView _view;
        private readonly string[] _leftMenuItems = { "Hjem", "Sager", "Lyskryds", "Kort", "Indstillinger" };

        public MenuPresenter(IMenuView view)
        {
            _view = view;
        }

        public string[] GetMenuItems()
        {
            return _leftMenuItems;
        }
        
        public void LeftMenuItemClicked(int position)
        {
            switch (_leftMenuItems[position])
            {
                case "Hjem":
                    _view.OnHomeClicked();
                    break;
                case "Sager":
                    break;
                case "Lyskryds":
                    _view.OnTrafficLightClicked();
                    break;
                case "Kort":
                    _view.OnMapClicked();
                    break;
                case "Indstillinger":
                    _view.OnSettingsClicked();
                    break;
            }
        }

        public void OnStop()
        {
            _view.HideLeftDrawer();
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
                case Android.Resource.Id.Home:
                    return _view.OnDrawerBtnClicked();
                case Resource.Id.Menu_Options:
                    return _view.OnSettingsClicked();
                case Resource.Id.Menu_About:
                    return true;
                case Resource.Id.Menu_LogOut:
                    return _view.OnLogOutClicked();
            }
            return false;
        }
    }
}