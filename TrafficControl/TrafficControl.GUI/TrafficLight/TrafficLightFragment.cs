using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using TrafficControl.BLL;
using TrafficControl.GUI.Adapters;

namespace TrafficControl.GUI.Lyskryds
{
    public class TrafficLightFragment : Fragment
    {
        public ListView TrafficLightView { get; private set; }
        public Activity ContextActivity { get; private set; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            ContextActivity = base.Activity;

            var view = inflater.Inflate(Resource.Layout.CasesFragment, container, false);

            TrafficLightView = view.FindViewById<ListView>(Resource.Id.CaseListing);

            return view;
        }
    }
}