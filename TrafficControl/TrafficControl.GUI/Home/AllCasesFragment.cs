using Android.OS;
using Android.Views;
using Android.Widget;
using TrafficControl.BLL;
using TrafficControl.GUI.Adapters;

namespace TrafficControl.GUI.Home
{
    public class AllCasesFragment : CasesFragment, IHomeView
    {
        private CaseAdapter _caseAdapter;
        private IHomePresenter _presenter;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            _presenter = new HomePresenter(this, ModelFactory.Instance.CreateHomeModel());
            _caseAdapter = new CaseAdapter(base.ContextActivity, _presenter.GetCases());
            
            CaseView.Adapter = _caseAdapter;
            CaseView.ItemClick += OnCaseItemClicked;

            return view;
        }

        private void OnCaseItemClicked(object sender, AdapterView.ItemClickEventArgs e)
        {
            _presenter.CaseItemClicked(base.ContextActivity, sender, e);
        }

        public void UpdateCaseView()
        {
            base.ContextActivity.RunOnUiThread(() => _caseAdapter.NotifyDataSetChanged());
        }
    }
}