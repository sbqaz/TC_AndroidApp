using System;
using NSubstitute;
using NUnit.Framework;
using TrafficControl.BLL.LogIn;
using TrafficControl.GUI.LogIn;

namespace TrafficControl.Test.Unit.LogIn
{
    [TestFixture]
    public class LogInPresenterTests
    {
        private LogInPresenter _uut;
        private ILogInView _fakeView;
        private ILogInModel _fakeModel;

        [SetUp]
        public void Init()
        {
            _fakeView = Substitute.For<ILogInView>();
            _fakeModel = Substitute.For<ILogInModel>();
            _uut = new LogInPresenter(_fakeView, _fakeModel);
        }

        [Test]
        public void LogInCredentialsAsync_EmailIsNull_EmailErrorSet()
        {
            _uut.LogInCredentialsAsync(null, "1234").Wait();
            _fakeView.Received().SetEmailError();
        }

        [Test]
        public void LogInCredentialsAsync_PasswordIsNull_PasswordErrorSet()
        {
            _uut.LogInCredentialsAsync("test", null).Wait();
            _fakeView.Received().SetPasswordError();
        }

        [Test]
        public void LogInCredentialsAsync_EmailIsNotNull_EmailErrorIsNotSet()
        {
            _uut.LogInCredentialsAsync("test", "1234").Wait();
            _fakeView.DidNotReceive().SetEmailError();
        }

        [Test]
        public void LogInCredentialsAsync_PasswordIsNotNull_PasswordErrorIsNotSet()
        {
            _uut.LogInCredentialsAsync("test", "1234").Wait();
            _fakeView.DidNotReceive().SetPasswordError();
        }

        [Test]
        public void LogInCredentialsAsync_EmailAndPasswordEntered_ProgressDialogShown()
        {
            _uut.LogInCredentialsAsync("test", "1234").Wait();
            _fakeView.Received().ShowProgressDialog();
        }

        [Test]
        public void LogInCredentialsAsync_CorrectEmailAndPasswordEntered_HidesLogInError()
        {
            _fakeModel.ValidateLogIn("test", "1234").Returns(true);
            _uut.LogInCredentialsAsync("test", "1234").Wait();
            _fakeView.Received().HideLogInErrorMsg();
        }

        [Test]
        public void LogInCredentialsAsync_CorrectEmailAndPasswordEntered_HidesProgressDialog()
        {
            _fakeModel.ValidateLogIn("test", "1234").Returns(true);
            _uut.LogInCredentialsAsync("test", "1234").Wait();
            _fakeView.Received().HideProgressDialog();
        }

        [Test]
        public void LogInCredentialsAsync_CorrectEmailAndPasswordEntered_NavigatesToHome()
        {
            _fakeModel.ValidateLogIn("test", "1234").Returns(true);
            _uut.LogInCredentialsAsync("test", "1234").Wait();
            _fakeView.Received().NavigateToHome();
        }

        [Test]
        public void LogInCredentialsAsync_IncorrectEmailEntered_ShowLogInError()
        {
            _fakeModel.ValidateLogIn("test", "1234").Returns(true);
            _uut.LogInCredentialsAsync("incorrect", "1234").Wait();
            _fakeView.Received().ShowLogInErrorMsg();
        }

        [Test]
        public void LogInCredentialsAsync_IncorrectPasswordEntered_HidesProgressDialog()
        {
            _fakeModel.ValidateLogIn("test", "1234").Returns(true);
            _uut.LogInCredentialsAsync("test", "incorrect").Wait();
            _fakeView.Received().HideProgressDialog();
        }
    }
}
