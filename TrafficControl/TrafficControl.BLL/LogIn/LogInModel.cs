using System;
using TrafficControl.DAL.RestSharp;

namespace TrafficControl.BLL.LogIn
{
    public class LogInModel : ILogInModel
    {
        private ITCApi _tcApi;
        public LogInModel(ITCApi tcApi)
        {
            _tcApi = tcApi;
        }

        public bool ValidateLogIn(string email, string password)
        {
            if (email == null) throw new ArgumentNullException(nameof(email));
            if (password == null) throw new ArgumentNullException(nameof(password));
            return _tcApi.LogIn(email, password);
        }
    }
}