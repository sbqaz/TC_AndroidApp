using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TrafficControl.DAL;

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
            return _tcApi.LogIn(email, password);
        }
    }
}