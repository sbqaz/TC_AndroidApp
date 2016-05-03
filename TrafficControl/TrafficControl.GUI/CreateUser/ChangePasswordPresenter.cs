using System.Threading.Tasks;
using TrafficControl.BLL.CreateUser;

namespace TrafficControl.GUI.CreateUser
{
    class ChangePasswordPresenter : IChangePasswordPresenter
    {
        private readonly IChangePasswordView _view;
        private readonly IChangePasswordModel _model;

        public ChangePasswordPresenter(IChangePasswordView view, IChangePasswordModel model)
        {
            _view = view;
            _model = model;
        }

        public async Task ChangePassword(string oldPw, string newPw, string confirmNewPw)
        {
            bool error = false;
            if (string.IsNullOrEmpty(oldPw))
            {
                _view.ShowMissingInfoError();
                _view.SetOldPasswordError();
                error = true;
            }
            else if (string.IsNullOrEmpty(newPw))
            {
                _view.ShowMissingInfoError();
                _view.SetNewPasswordError();
                error = true;
            }
            else if (string.IsNullOrEmpty(confirmNewPw))
            {
                _view.ShowMissingInfoError();
                _view.SetConfirmNewPasswordError();
                error = true;
            }

            if (newPw != confirmNewPw)
            {
                _view.ConfirmNewPasswordNotMatchingError();
                error = true;
            }

            if (!error)
            {
                _view.ShowProgressDialog();
                var userCreated = await Task.Factory.StartNew(() => _model.ChangePassword(oldPw, newPw));
                if (userCreated)
                {
                    _view.HideProgressDialog();
                    _view.PasswordChanged();
                }
                else
                {
                    _view.HideProgressDialog();
                    _view.PasswordNotChanged();
                }
            }
        }
    }
}