using TrafficControl.DAL.RestSharp;

namespace TrafficControl.BLL.CreateUser
{
    public class ChangePasswordModel : IChangePasswordModel
    {
        private readonly ITCApi _tcApi;

        public ChangePasswordModel(ITCApi tcApi)
        {
            _tcApi = tcApi;
        }

        public bool ChangePassword(string oldPw, string newPw)
        {
            return _tcApi.ChangePassword(oldPw, newPw, newPw);
        }
    }
}