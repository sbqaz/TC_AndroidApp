using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using TrafficControl.BLL;
using TrafficControl.GUI.Adapters;

namespace TrafficControl.GUI.Home
{
    public class MyCasesFragment : CasesFragment, IHomeView
    {
        private CaseAdapter _caseAdapter;
        private IHomePresenter _presenter;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            _presenter = new HomePresenter(this, ModelFactory.Instance.CreateHomeModel());
            _caseAdapter = new CaseAdapter(base.ContextActivity, _presenter.GetMyCases());

            CaseView.Adapter = _caseAdapter;
            CaseView.ItemClick += OnCaseItemClicked;
            
            return view;
        }

        public override void OnResume()
        {
            base.OnResume();
            _caseAdapter.NotifyDataSetChanged();
        }

        private void OnCaseItemClicked(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (GetType() != typeof(CaseActivity))
            {
                var nextActivity = new Intent(Activity, typeof(CaseActivity));
                var bundle = new Bundle();
                bundle.PutLong(GetString(Resource.String.PASS_CASE_ID), _presenter.GetMyCases()[e.Position].Id);
                nextActivity.AddFlags(ActivityFlags.ReorderToFront);
                nextActivity.PutExtras(bundle);
                StartActivity(nextActivity);
            }
        }
    }
}