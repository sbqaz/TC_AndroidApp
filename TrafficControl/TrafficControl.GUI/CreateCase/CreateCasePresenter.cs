using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrafficControl.BLL.CreateCase;

namespace TrafficControl.GUI.CreateCase
{
    public class CreateCasePresenter : ICreateCasePresenter
    {
        private readonly ICreateCaseView _view;
        private readonly ICreateCaseModel _model;

        public CreateCasePresenter(ICreateCaseView view, ICreateCaseModel model)
        {
            _view = view;
            _model = model;
            _model.FetchData();
        }
        
        public List<string> GetInformers()
        {
            return _model.Informers;
        }

        public List<string> GetInstallations()
        {
            return _model.Installations.Keys.ToList();
        }

        public async Task CreateCase(string installation, string informer, string errorDescription)
        {
            bool error = false;
            if (string.IsNullOrEmpty(installation))
            {
                _view.ShowMissingInfoError();
                _view.SetInstallationError();
                error = true;
            }
            else if (string.IsNullOrEmpty(informer))
            {
                _view.ShowMissingInfoError();
                _view.SetInformerError();
                error = true;
            }
            else if (string.IsNullOrEmpty(errorDescription))
            {
                _view.ShowMissingInfoError();
                _view.SetErrorDescriptionError();
                error = true;
            }

            if (!error)
            {
                _view.ShowProgressDialog();
                var caseCreated = await Task.Factory.StartNew(() => _model.CreateCase(installation, informer, errorDescription));
                if (caseCreated)
                {
                    _view.HideProgressDialog();
                    _view.CaseCreated();
                }
                else
                {
                    _view.HideProgressDialog();
                    _view.CaseNotCreated();
                }
            }
        }
    }
}