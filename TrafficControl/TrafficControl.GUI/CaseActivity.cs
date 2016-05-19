using System;
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
        private ProgressDialog _progressDialog;
        private EditText _repairMade;
        private EditText _userComment;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            _presenter = new CasePresenter(this, ModelFactory.Instance.CreateCaseModel());

            _progressDialog = new ProgressDialog(this);
            _progressDialog.SetMessage("Tager sag...");

            if (this.Intent.Extras != null)
            {
                var caseId = this.Intent.Extras.GetLong(GetString(Resource.String.PASS_CASE_ID));

                _presenter.SetCurrentCase(caseId);
                _presenter.SetContentView(_presenter.CurrentCase);
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

        public void SetContentViewCreated()
        {
            SetContentView(Resource.Layout.ViewCaseCreated);

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

                Button claimCase = FindViewById<Button>(Resource.Id.viewcase_claim_btn);
                claimCase.Click += OnClaimCaseClicked;
            }
        }

        private void OnClaimCaseClicked(object sender, EventArgs e)
        {
            _presenter.ClaimCase();
        }

        public void SetContentViewStarted()
        {
            SetContentView(Resource.Layout.ViewCaseStarted);

            if (_presenter.CurrentCase != null)
            {
                TextView installationName = FindViewById<TextView>(Resource.Id.viewcasestarted_installation_name);
                installationName.Text = _presenter.CurrentCase.Installation.Name;

                TextView worker = FindViewById<TextView>(Resource.Id.viewcasestarted_worker);
                worker.Text = _presenter.CurrentCase.Worker;

                TextView status = FindViewById<TextView>(Resource.Id.viewcasestarted_status);
                status.Text = _presenter.CaseStatusToString(_presenter.CurrentCase.Status);

                TextView informer = FindViewById<TextView>(Resource.Id.viewcasestarted_informer);
                informer.Text = _presenter.CaseObserverToString(_presenter.CurrentCase.Observer);

                TextView time = FindViewById<TextView>(Resource.Id.viewcasestarted_time);
                time.Text = _presenter.CurrentCase.Time != null ? _presenter.CurrentCase.Time.Value.ToString("dd-MMM-yyyy ddd HH:mm.ss") : "n/a";

                TextView errorDescription = FindViewById<TextView>(Resource.Id.viewcasestarted_errorDescription);
                errorDescription.Text = _presenter.CurrentCase.ErrorDescription;
                
                _repairMade = FindViewById<EditText>(Resource.Id.viewcasestarted_repairMade);
                _repairMade.Text = _presenter.CurrentCase.MadeRepair;

                _userComment = FindViewById<EditText>(Resource.Id.viewcasestarted_userComment);
                _userComment.Text = _presenter.CurrentCase.UserComment;

                Button finishCase = FindViewById<Button>(Resource.Id.viewcasestarted_finish_btn);
                finishCase.Click += OnFinishCaseClicked;

                Button pendingCase = FindViewById<Button>(Resource.Id.viewcasestarted_pending_btn);
                pendingCase.Click += OnPendingCaseClicked;
            }
        }

        private void OnPendingCaseClicked(object sender, EventArgs e)
        {
            _presenter.PendingCase(_repairMade.Text, _userComment.Text);
        }

        private void OnFinishCaseClicked(object sender, EventArgs e)
        {
            _presenter.FinishCase(_repairMade.Text, _userComment.Text);
        }

        public void SetContentViewPending()
        {
            SetContentView(Resource.Layout.ViewCasePending);

            if (_presenter.CurrentCase != null)
            {
                
            }
        }

        public void SetContentViewDone()
        {
            throw new System.NotImplementedException();
        }

        public void NoCurrentCase()
        {
            string toast = "Der er ingen sag";
            Toast.MakeText(this, toast, ToastLength.Short).Show();
        }

        public void ShowProgressDialog()
        {
            _progressDialog.Show();
        }

        public void HideProgressDialog()
        {
            _progressDialog.Hide();
        }

        public void CaseNotClaimed()
        {
            string toast = "Kunne ikke tage sag";
            Toast.MakeText(this, toast, ToastLength.Short).Show();
        }

        public void CaseClaimed()
        {
            string toast = "Sag taget";
            Toast.MakeText(this, toast, ToastLength.Short).Show();
            Finish();
        }

        public void CaseNotFinished()
        {
            string toast = "Kunne ikke færdiggøre sag";
            Toast.MakeText(this, toast, ToastLength.Short).Show();
        }

        public void CaseFinished()
        {
            string toast = "Sag færdiggjort";
            Toast.MakeText(this, toast, ToastLength.Short).Show();
            Finish();
        }

        public void CaseNotSetPending()
        {
            string toast = "Kunne ikke færdiggøre sættes til afventer";
            Toast.MakeText(this, toast, ToastLength.Short).Show();
        }

        public void CaseSetPending()
        {
            string toast = "Sag sat til afventer";
            Toast.MakeText(this, toast, ToastLength.Short).Show();
            Finish();
        }
    }
}