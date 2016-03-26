using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using TrafficControl.GUI.Adapters;

namespace TrafficControl.GUI.Home
{
    public class CasesFragment : Fragment
    {
        private ListView _caseView;
        private CaseAdapter _caseAdapter;
        private IHomePresenter _parentPresenter;
        public CasesFragment(CaseAdapter caseAdapter, IHomePresenter parentPresenter) : base()
        {
            _caseAdapter = caseAdapter;
            _parentPresenter = parentPresenter;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            
            var view = inflater.Inflate(Resource.Layout.CasesFragment, container, false);

            _caseView = view.FindViewById<ListView>(Resource.Id.CaseListing);
            _caseView.Adapter = _caseAdapter;
            _caseView.ItemClick += OnCaseItemClicked;

            return view;
        }

        private void OnCaseItemClicked(object sender, AdapterView.ItemClickEventArgs e)
        {
            _parentPresenter.CaseItemClicked(Activity, sender, e);
        }
    }
}