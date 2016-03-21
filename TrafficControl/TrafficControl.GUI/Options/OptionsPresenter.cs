using TrafficControl.BLL.Options;

namespace TrafficControl.GUI.Options
{
    public class OptionsPresenter : IOptionsPresenter
    {
        private IOptionsView _optionsView;
        private IOptionsModel _optionsModel;

        public OptionsPresenter(IOptionsView optionsView, IOptionsModel optionsModel)
        {
            _optionsView = optionsView;
            _optionsModel = optionsModel;
        }
    }
}