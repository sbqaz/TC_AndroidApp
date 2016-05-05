using System.Collections.Generic;
using Android.App;
using Android.Widget;
using TrafficControl.BLL;
using TrafficControl.BLL.Home;
using TrafficControl.BLL.Observer;
using TrafficControl.DAL.RestSharp.Types;

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
            
            //_homeModel.Run();
            _homeModel.Attach(this);
        }

        public void OnDestroy()
        {
            _homeView = null;
        }

        public List<Case> GetCases()
        {
            return _homeModel.Cases;
        }

        public List<Case> GetMyCases()
        {
            return _homeModel.MyCases;
        }

        public void FetchMyCases()
        {
            _homeModel.FetchMyCases();
        }

        public void FetchCases()
        {
            _homeModel.FetchCases();
        }

        public void OnPause()
        {
            _homeModel.Detach(this);
        }

        public void Update(IHomeModel subject)
        {
            if (_homeView != null)
                _homeView.UpdateCaseView();
        }
    }
}