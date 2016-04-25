using TrafficControl.DAL.RestSharp;

namespace TrafficControl.BLL.CreateUser
{
    class ChangePasswordModel : IChangePasswordModel
    {
        private readonly ITCApi _tcApi;

        public ChangePasswordModel(ITCApi tcApi)
        {
            _tcApi = tcApi;
        }
    }
}