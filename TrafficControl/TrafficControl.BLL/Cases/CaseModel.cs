using TrafficControl.DAL.RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.BLL.Cases
{
    public class CaseModel : ICaseModel
    {
        private readonly ITCApi _api;

        public CaseModel(ITCApi api)
        {
            _api = api;
        }

        public Case GetCase(long caseId)
        {
            return _api.GetCase((int)caseId);
        }
    }
}