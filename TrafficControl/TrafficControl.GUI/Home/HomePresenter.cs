using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using TrafficControl.BLL;
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

        public List<Case> GetCases()
        {
            return _homeModel.Cases;
        }

        public List<Case> GetMyCases()
        {
            return _homeModel.MyCases;
        }

        //Move to view?
        public void CaseItemClicked(Activity activity, object sender, AdapterView.ItemClickEventArgs e)
        {
            string text = string.Format("Casename: {0}\n" +
                                        "Case Id: {1}", GetCases()[e.Position].Name, GetCases()[e.Position].Id);
            
            new AlertDialog.Builder(activity).SetPositiveButton("Ok", (msender, args) => { })
                                                            .SetMessage(text)
                                                            .SetTitle("Case")
                                                            .Show();
        }

        public void Update(IHomeModel subject)
        {
            if (_homeView != null)
                _homeView.UpdateCaseView();
        }
    }
}