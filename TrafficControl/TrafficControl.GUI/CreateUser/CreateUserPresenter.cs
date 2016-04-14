using System.Threading.Tasks;
using TrafficControl.BLL.CreateUser;

namespace TrafficControl.GUI.CreateUser
{
    public class CreateUserPresenter : ICreateUserPresenter
    {
        private readonly ICreateUserView _view;
        private readonly ICreateUserModel _model;

        public CreateUserPresenter(ICreateUserView view, ICreateUserModel model)
        {
            _view = view;
            _model = model;
        }

        public async Task OnCreateUserClick(string email, string password, string confirmPassword, string name, string phoneNumber, string userType)
        {
            bool error = false;
            if (string.IsNullOrEmpty(email))
            {
                _view.ShowMissingInfoError();
                _view.SetEmailError();
                error = true;
            }
            else if (string.IsNullOrEmpty(password))
            {
                _view.ShowMissingInfoError();
                _view.SetPasswordError();
                error = true;
            }
            else if (string.IsNullOrEmpty(confirmPassword))
            {
                _view.ShowMissingInfoError();
                _view.SetConfirmPasswordError();
                error = true;
            }
            else if (string.IsNullOrEmpty(name))
            {
                _view.ShowMissingInfoError();
                _view.SetNameError();
                error = true;
            }
            else if (string.IsNullOrEmpty(phoneNumber))
            {
                _view.ShowMissingInfoError();
                _view.SetPhoneNumberError();
                error = true;
            }

            if (confirmPassword != password)
            {
                _view.ConfirmPasswordNotMatchingError();
                error = true;
            }

            if (!error)
            {
                _view.ShowProgressDialog();
                var userCreated = await Task.Factory.StartNew(() => _model.CreateUser(email, password, name, phoneNumber, userType));
                if (userCreated)
                {
                    _view.HideProgressDialog();
                    _view.UserCreated();
                }
                else
                {
                    _view.HideProgressDialog();
                    _view.UserNotCreated();
                }
            }
        }
    }
}