using System;
using System.Threading.Tasks;
using TrafficControl.BLL.Cases;
using TrafficControl.DAL.RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.GUI.Cases
{
    public class CasePresenter : ICasePresenter
    {
        private readonly ICaseView _view;
        private readonly ICaseModel _model;
        public Case CurrentCase { get; private set; }
        
        public CasePresenter(ICaseView view, ICaseModel model)
        {
            _view = view;
            _model = model;
        }

        public void SetCurrentCase(long caseId)
        {
            var currentCase = _model.GetCase(caseId);
            if (currentCase != null)
            {
                CurrentCase = currentCase;
            }
        }

        public string CaseStatusToString(CaseStatus status)
        {
            string retval = "_NO_STATUS_";
            if (status == CaseStatus.Created)
            {
                retval = "Oprettet";
            }
            else if (status == CaseStatus.Done)
            {
                retval = "Udført";
            }
            else if (status == CaseStatus.Pending)
            {
                retval = "Afventer";
            }
            else if (status == CaseStatus.Started)
            {
                retval = "Begyndt";
            }
            return retval;
        }

        public string CaseObserverToString(ObserverSelection observer)
        {
            string retval = "_NO_VALUE_";
            if (observer == ObserverSelection.Police)
            {
                retval = "Politiet";
            }
            else if (observer == ObserverSelection.User)
            {
                retval = "Kommunen";
            }
            else if (observer == ObserverSelection.Own)
            {
                retval = "Montør";
            }
            else if (observer == ObserverSelection.ThirdPart)
            {
                retval = "Borger";
            }
            else if (observer == ObserverSelection.Undefined)
            {
                retval = "Ikke defineret";
            }
            return retval;
        }

        public void SetContentView(Case @case)
        {
            if (@case == null) return;
            switch (@case.Status)
            {
                case CaseStatus.Created:
                    _view.SetContentViewCreated();
                    break;
                case CaseStatus.Started:
                    _view.SetContentViewStarted();
                    break;
                case CaseStatus.Pending:
                    _view.SetContentViewPending();
                    break;
                case CaseStatus.Done:
                    _view.SetContentViewDone();
                    break;
            }
        }

        public async Task ClaimCase()
        {
            if (CurrentCase != null)
            {
                _view.ShowProgressDialog();
                bool result = await Task.Factory.StartNew(() => _model.ClaimCase(CurrentCase.Id));
                if (!result)
                {
                    _view.HideProgressDialog();
                    _view.CaseNotClaimed();
                }
                else
                {
                    _view.HideProgressDialog();
                    _view.CaseClaimed();
                }
            }
            else
            {
                _view.NoCurrentCase();
            }
        }

        public void FinishCase(string repairMade, string userComment)
        {
            CurrentCase.Status = CaseStatus.Done;
            CurrentCase.MadeRepair = repairMade;
            CurrentCase.UserComment = userComment;

            var result = _model.UpdateCase(CurrentCase);
            if (!result)
            {
                _view.CaseNotFinished();
            }
            else
            {
                _view.CaseFinished();
            }
        }

        public void PendingCase(string repairMade, string userComment)
        {
            CurrentCase.Worker = "";
            CurrentCase.Status = CaseStatus.Pending;
            CurrentCase.MadeRepair = repairMade;
            CurrentCase.UserComment = userComment;

            var result = _model.UpdateCase(CurrentCase);
            if (!result)
            {
                _view.CaseNotSetPending();
            }
            else
            {
                _view.CaseSetPending();
            }
        }

        public void SaveUserComment(string userComment)
        {
            CurrentCase.UserComment = userComment;

            var result = _model.UpdateCase(CurrentCase);
            if (!result)
            {
                _view.CaseNotSaved();
            }
            else
            {
                _view.CaseSaved();
            }
        }
    }
}