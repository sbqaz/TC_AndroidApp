using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using TrafficControl.BLL;
using TrafficControl.GUI.CreateCase;

namespace TrafficControl.GUI
{
    [Activity(Label = "Opret sag")]
    public class CreateCaseActivity : Activity, ICreateCaseView
    {
        private ICreateCasePresenter _presenter;
        private AutoCompleteTextView _installation;
        private EditText _errorDescription;
        private Button _createCaseBtn;
        private ProgressDialog _progressDialog;
        private Spinner _informerSpinner;
        private string _informerSelected;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CreateCase);

            _presenter = new CreateCasePresenter(this, ModelFactory.Instance.CreateCreateCaseModel());

            var installationAdapter = new ArrayAdapter<string>(this, Resource.Layout.SideMenuItem, _presenter.GetInstallations());
            _installation = FindViewById<AutoCompleteTextView>(Resource.Id.create_case_installation);
            _installation.Adapter = installationAdapter;

            _informerSpinner = FindViewById<Spinner>(Resource.Id.create_case_informer);
            _informerSpinner.ItemSelected += spinner_ItemSelected;
            var adapter = new ArrayAdapter<string>(this, Resource.Layout.SideMenuItem, _presenter.GetInformers());
            adapter.SetDropDownViewResource(Resource.Layout.UserTypeDropDownItem);
            _informerSpinner.Adapter = adapter;

            _errorDescription = FindViewById<EditText>(Resource.Id.create_case_errorDescription);
            _createCaseBtn = FindViewById<Button>(Resource.Id.create_case_btn);
            _createCaseBtn.Click += OnCreateCaseClicked;

            _progressDialog = new ProgressDialog(this);
            _progressDialog.SetMessage("Opretter ny sag...");

            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            _informerSelected = (string)_informerSpinner.GetItemAtPosition(e.Position);
        }

        private void OnCreateCaseClicked(object sender, EventArgs e)
        {
            _presenter.CreateCase(_installation.Text, _informerSelected, _errorDescription.Text);
        }

        public override bool OnMenuItemSelected(int featureId, IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                Finish();
            }
            return base.OnMenuItemSelected(featureId, item);
        }

        public void ShowMissingInfoError()
        {
            string toast = "Alle felter skal udfyldes";
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        public void SetInstallationError()
        {
            _installation.RequestFocus();
            _installation.SetError("Skal udfyldes", null);
        }

        public void SetInformerError()
        {
            _informerSpinner.RequestFocus();
        }

        public void SetErrorDescriptionError()
        {
            _errorDescription.RequestFocus();
            _errorDescription.SetError("Skal udfyldes", null);
        }

        public void ShowProgressDialog()
        {
            _progressDialog.Show();
        }

        public void HideProgressDialog()
        {
            _progressDialog.Hide();
        }

        public void CaseCreated()
        {
            string toast = "Sag oprettet";
            Toast.MakeText(this, toast, ToastLength.Short).Show();
            Finish();
        }

        public void CaseNotCreated()
        {
            string toast = "Kunne ikke oprette ny sag, tjek forbindelsen";
            Toast.MakeText(this, toast, ToastLength.Short).Show();
        }
    }
}