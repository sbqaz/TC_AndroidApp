using TrafficControl.BLL.Cases;
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
    }
}