namespace TrafficControl.GUI.Menu
{
    public interface IMenuView
    {
        void OnHomeClicked();
        bool OnSettingsClicked();
        bool OnDrawerBtnClicked();
        bool OnAboutClicked();
        bool OnLogOutClicked();
        void HideLeftDrawer();
    }
}