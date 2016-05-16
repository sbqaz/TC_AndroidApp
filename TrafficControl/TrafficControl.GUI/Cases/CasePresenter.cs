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
    }
}