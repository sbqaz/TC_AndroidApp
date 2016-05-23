using Android.OS;
using Android.Views;
using Android.Widget;
using TrafficControl.BLL;
using TrafficControl.GUI.Adapters;

namespace TrafficControl.GUI.Lyskryds
{
    public class AllTrafficLightFragment : TrafficLightFragment, ITrafficLightOverviewView
    {
        private TrafficLightListAdapter _trafficLightAdapter;
        private ITrafficViewOverViewPresenter _presenter;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            _presenter = new TrafficLightOverviewPresenter(this, ModelFactory.Instance.CreateLyskrydsModel());
            _trafficLightAdapter = new TrafficLightListAdapter(base.ContextActivity, _presenter.GetTrafficLights());

            TrafficLightView.Adapter = _trafficLightAdapter;
            TrafficLightView.ItemClick += OnTrafficLightItemClicked;
           
            return view;
        }

        private void OnTrafficLightItemClicked(object sender, AdapterView.ItemClickEventArgs e)
        {
            _presenter.TrafficLightClicked(base.ContextActivity, sender, e);
        }

        public void UpdateCaseView()
        {
            base.ContextActivity.RunOnUiThread(() => _trafficLightAdapter.NotifyDataSetChanged());
        }
    }
}