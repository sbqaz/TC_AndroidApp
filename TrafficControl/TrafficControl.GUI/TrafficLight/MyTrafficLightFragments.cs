﻿using Android.OS;
using Android.Views;
using TrafficControl.BLL;
using TrafficControl.GUI.Adapters;
using TrafficControl.GUI.Lyskryds;

namespace TrafficControl.GUI.TrafficLight
{
    public class MyTrafficLightFragment : TrafficLightFragment, ITrafficLightOverviewView
    {
        private TrafficLightListAdapter _trafficLightAdapter;
        private ITrafficViewOverViewPresenter _presenter;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            _presenter = new TrafficLightOverviewPresenter(this, ModelFactory.Instance.CreateLyskrydsModel());
            _trafficLightAdapter = new TrafficLightListAdapter(base.ContextActivity, _presenter.GetTrafficLights());

            TrafficLightView.Adapter = _trafficLightAdapter;
           
            return view;
        }

      
        public void UpdateCaseView()
        {
            base.ContextActivity.RunOnUiThread(() => _trafficLightAdapter.NotifyDataSetChanged());
        }
    }
}