using Android.App;
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

        private void OnCaseItemClicked(object sender, AdapterView.ItemClickEventArgs e)
        {
            string text = string.Format("Casename: {0}\n" +
                                        "Case Id: {1}", _presenter.GetMyCases()[e.Position].Worker, _presenter.GetMyCases()[e.Position].Id);

            new AlertDialog.Builder(ContextActivity).SetPositiveButton("Ok", (msender, args) => { })
                                                            .SetMessage(text)
                                                            .SetTitle("Case")
                                                            .Show();
        }

        //public void UpdateCaseView()
        //{
        //    if(_caseAdapter != null)
        //        base.ContextActivity.RunOnUiThread(() => _caseAdapter.NotifyDataSetChanged());
        //}
    }
}