using System.Linq;
using Android.Content;
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
            
            return view;
        }

        public override void OnResume()
        {
            base.OnResume();

            _caseAdapter = new CaseAdapter(base.ContextActivity, _presenter.GetCases().ToList());

            CaseView.Adapter = _caseAdapter;
            CaseView.ItemClick += OnCaseItemClicked;
        }

        private void OnCaseItemClicked(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (GetType() != typeof(CaseActivity))
            {
                var nextActivity = new Intent(Activity, typeof(CaseActivity));
                var bundle = new Bundle();
                bundle.PutLong(GetString(Resource.String.PASS_CASE_ID), _presenter.GetCases()[e.Position].Id);
                nextActivity.AddFlags(ActivityFlags.ReorderToFront);
                nextActivity.PutExtras(bundle);
                StartActivity(nextActivity);
            }
        }
    }
}