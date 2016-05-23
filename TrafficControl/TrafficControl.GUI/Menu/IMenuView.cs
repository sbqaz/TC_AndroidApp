namespace TrafficControl.GUI.Menu
{
    public interface IMenuView
    {
        void OnHomeClicked();
        bool OnSettingsClicked();
        bool OnDrawerBtnClicked();
        bool OnMapClicked();
        bool OnLogOutClicked();
        void HideLeftDrawer();
        void OnTrafficLightClicked();
    }
}