using System.Threading.Tasks;
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

        //Redundant?
        public void OnDestroy()
        {
            _logInView = null;
        }

        public async Task LogInCredentialsAsync(string email, string password)
        {
            bool error = false;
            if (string.IsNullOrEmpty(email))
            {
                _logInView.SetEmailError();
                error = true;
            }
            if (string.IsNullOrEmpty(password))
            {
                _logInView.SetPasswordError();
                error = true;
            }

            if (!error)
            {
                _logInView.ShowProgressDialog();
                var validation = await Task.Factory.StartNew(() => _logInModel.ValidateLogIn(email, password));

                //Validate email "syntax" aswell??
                if (validation)
                {
                    _logInView.HideLogInErrorMsg();
                    _logInView.HideProgressDialog();
                    _logInView.NavigateToHome();
                }
                else
                {
                    _logInView.ShowLogInErrorMsg();
                    _logInView.HideProgressDialog();
                }
            }
        }
    }
}