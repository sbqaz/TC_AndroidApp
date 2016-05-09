using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Widget;
using TrafficControl.BLL;
using TrafficControl.BLL.Home;
using TrafficControl.BLL.Observer;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.GUI.Home
{
    public class HomePresenter : IHomePresenter
    {
        private IHomeView _homeView;
        private IHomeModel _homeModel;

        public HomePresenter(IHomeView homeView, IHomeModel homeModel)
        {
            _homeView = homeView;
            _homeModel = homeModel;
        }

        public void OnDestroy()
        {
            _homeView = null;
        }

        public List<Case> GetCases()
        {
            return _homeModel.Cases;
        }

        public async Task<List<Case>> GetCasesAsync()
        {
            var retval = await Task.Factory.StartNew(() => _homeModel.Cases);
            return retval;
        }

        public List<Case> GetMyCases()
        {
            return _homeModel.MyCases;
        }
    }
}