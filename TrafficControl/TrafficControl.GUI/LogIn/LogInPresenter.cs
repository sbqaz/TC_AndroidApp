using Android.Text;
using TrafficControl.BLL.LogIn;

namespace TrafficControl.GUI.LogIn
{
    public class LogInPresenter : ILogInPresenter
    {
        private ILogInModel _logInModel;
        private ILogInView _logInView;
        public LogInPresenter(ILogInView view, ILogInModel model)
        {
            _logInView = view;
            _logInModel = model;
        }

        public void OnDestroy()
        {
            _logInView = null;
        }

        public void LogInCredentials(string email, string password)
        {
            bool error = false;
            if (TextUtils.IsEmpty(email))
            {
                _logInView.SetEmailError();
                error = true;
            }
            if (TextUtils.IsEmpty(password))
            {
                _logInView.SetPasswordError();
                error = true;
            }

            if (!error)
            {
                //Validate email aswell??
                if (_logInModel.ValidateLogIn(email, _logInModel.EncryptPassword(password)))
                {
                    _logInView.NavigateToHome();
                    _logInView.HideLogInErrorMsg();
                }
                else
                {
                    _logInView.ShowLogInErrorMsg();
                }
            }
        }
    }
}