using TrafficControl.BLL.Home;
using TrafficControl.BLL.Observer;

namespace TrafficControl.GUI.Home
{
    public class HomePresenter : IHomePresenter, IObserver<IHomeModel>
    {
        private IHomeView _homeView;
        private IHomeModel _homeModel;

        public HomePresenter(IHomeView homeView, IHomeModel homeModel)
        {
            _homeView = homeView;
            _homeModel = homeModel;
            
            _homeModel.Attach(this);
        }

        public void OnDestroy()
        {
            _homeView = null;
        }

        public void Update(IHomeModel subject)
        {
            if (_homeView != null)
                _homeView.AddCase(subject.NewCase);
        }
    }
}