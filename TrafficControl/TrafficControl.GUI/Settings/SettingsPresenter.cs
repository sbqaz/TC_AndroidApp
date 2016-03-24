using TrafficControl.BLL.Settings;

namespace TrafficControl.GUI.Settings
{
    public class SettingsPresenter : ISettingsPresenter
    {
        private ISettingsView _settingsView;
        private ISettingsModel _settingsModel;

        public SettingsPresenter(ISettingsView settingsView, ISettingsModel settingsModel)
        {
            _settingsView = settingsView;
            _settingsModel = settingsModel;
        }
    }
}