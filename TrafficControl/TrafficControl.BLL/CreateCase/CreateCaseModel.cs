using TrafficControl.DAL.RestSharp;

namespace TrafficControl.BLL.CreateCase
{
    class CreateCaseModel : ICreateCaseModel
    {
        private ITCApi _api;

        public CreateCaseModel(ITCApi api)
        {
            _api = api;
        }
    }
}