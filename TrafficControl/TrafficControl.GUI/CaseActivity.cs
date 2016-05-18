using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using TrafficControl.BLL;
using TrafficControl.DAL.RestSharp.Types;
using TrafficControl.GUI.Cases;
using TrafficControl.GUI.Home;

namespace TrafficControl.GUI
{
    [Activity(Label = "CaseActivity")]
    public class CaseActivity : Activity, ICaseView
    {
        private ICasePresenter _presenter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ViewCaseCreated);
            
            _presenter = new CasePresenter(this, ModelFactory.Instance.CreateCaseModel());

            if (this.Intent.Extras != null)
            {
                var caseId = this.Intent.Extras.GetLong(GetString(Resource.String.PASS_CASE_ID));

                _presenter.SetCurrentCase(caseId);
            }

            if (_presenter.CurrentCase != null)
            {
                TextView installationName = FindViewById<TextView>(Resource.Id.viewcase_installation_name);
                installationName.Text = _presenter.CurrentCase.Installation.Name;

                TextView worker = FindViewById<TextView>(Resource.Id.viewcase_worker);
                worker.Text = _presenter.CurrentCase.Worker;

                TextView status = FindViewById<TextView>(Resource.Id.viewcase_status);
                status.Text = _presenter.CaseStatusToString(_presenter.CurrentCase.Status);

                TextView informer = FindViewById<TextView>(Resource.Id.viewcase_informer);
                informer.Text = _presenter.CaseObserverToString(_presenter.CurrentCase.Observer);

                TextView time = FindViewById<TextView>(Resource.Id.viewcase_time);
                time.Text = _presenter.CurrentCase.Time != null ? _presenter.CurrentCase.Time.Value.ToString("dd-MMM-yyyy ddd HH:mm.ss") : "n/a";

                TextView errorDescription = FindViewById<TextView>(Resource.Id.viewcase_errorDescription);
                errorDescription.Text = _presenter.CurrentCase.ErrorDescription;

                TextView repairMade = FindViewById<TextView>(Resource.Id.viewcase_repairMade);
                repairMade.Text = _presenter.CurrentCase.MadeRepair;

                TextView userComment = FindViewById<TextView>(Resource.Id.viewcase_userComment);
                userComment.Text = _presenter.CurrentCase.UserComment;
            }
            

            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
        }

        public override bool OnMenuItemSelected(int featureId, IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                Finish();
            }
            return base.OnMenuItemSelected(featureId, item);
        }
    }
}