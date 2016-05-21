using NSubstitute;
using NUnit.Framework;
using TrafficControl.BLL.CreateUser;
using TrafficControl.GUI.CreateUser;

namespace TrafficControl.Test.Unit.CreateUser
{
    [TestFixture]
    public class ChangePasswordPresenterTests
    {
        private IChangePasswordModel _fakeModel;
        private IChangePasswordView _fakeView;
        private ChangePasswordPresenter _uut;

        [SetUp]
        public void Init()
        {
            _fakeView = Substitute.For<IChangePasswordView>();
            _fakeModel = Substitute.For<IChangePasswordModel>();
            _uut = new ChangePasswordPresenter(_fakeView, _fakeModel);
        }

        [Test]
        public void ChangePassword_OldPwNull_ShowMissingInfoErrorCalled()
        {
            _uut.ChangePassword(null, "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void ChangePassword_OldPwNull_SetOldPasswordErrorCalled()
        {
            _uut.ChangePassword(null, "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().SetOldPasswordError();
        }

        [Test]
        public void ChangePassword_OldPwEmpty_ShowMissingInfoErrorCalled()
        {
            _uut.ChangePassword("", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void ChangePassword_OldPwEmpty_SetOldPasswordErrorCalled()
        {
            _uut.ChangePassword("", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().SetOldPasswordError();
        }

        [Test]
        public void ChangePassword_NewPwNull_ShowMissingInfoErrorCalled()
        {
            _uut.ChangePassword("NotEmpty", null, "NotEmpty").Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void ChangePassword_NewPwNull_SetNewPasswordErrorCalled()
        {
            _uut.ChangePassword("NotEmpty", null, "NotEmpty").Wait();
            _fakeView.Received().SetNewPasswordError();
        }

        [Test]
        public void ChangePassword_NewPwEmpty_ShowMissingInfoErrorCalled()
        {
            _uut.ChangePassword("NotEmpty", "", "NotEmpty").Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void ChangePassword_NewPwEmpty_SetNewPasswordErrorCalled()
        {
            _uut.ChangePassword("NotEmpty", "", "NotEmpty").Wait();
            _fakeView.Received().SetNewPasswordError();
        }

        [Test]
        public void ChangePassword_ConfirmNewPwNull_ShowMissingInfoErrorCalled()
        {
            _uut.ChangePassword("NotEmpty", "NotEmpty", null).Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void ChangePassword_ConfirmNewPwNull_SetConfirmNewPasswordErrorCalled()
        {
            _uut.ChangePassword("NotEmpty", "NotEmpty", null).Wait();
            _fakeView.Received().SetConfirmNewPasswordError();
        }

        [Test]
        public void ChangePassword_ConfirmNewPwEmpty_ShowMissingInfoErrorCalled()
        {
            _uut.ChangePassword("NotEmpty", "NotEmpty", "").Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void ChangePassword_ConfirmNewPwEmpty_SetConfirmNewPasswordErrorCalled()
        {
            _uut.ChangePassword("NotEmpty", "NotEmpty", "").Wait();
            _fakeView.Received().SetConfirmNewPasswordError();
        }

        [Test]
        public void ChangePassword_NewPwAndConfirmNewPwNotTheSame_ConfirmNewPasswordNotMatchingErrorCalled()
        {
            _uut.ChangePassword("NotEmpty", "Not", "TheSame").Wait();
            _fakeView.Received().ConfirmNewPasswordNotMatchingError();
        }

        [Test]
        public void ChangePassword_ValidInfo_ShowProgressDialogCalled()
        {
            _uut.ChangePassword("NotEmpty", "Same", "Same").Wait();
            _fakeView.Received().ShowProgressDialog();
        }

        [Test]
        public void ChangePassword_ValidInfo_HideProgressDialogCalled()
        {
            _fakeModel.ChangePassword("OldValid", "Valid").Returns(true);
            _uut.ChangePassword("OldValid", "Valid", "Valid").Wait();
            _fakeView.Received().HideProgressDialog();
        }

        [Test]
        public void ChangePassword_ValidInfo_PasswordChangedCalled()
        {
            _fakeModel.ChangePassword("OldValid", "Valid").Returns(true);
            _uut.ChangePassword("OldValid", "Valid", "Valid").Wait();
            _fakeView.Received().PasswordChanged();
        }

        [Test]
        public void ChangePassword_InvalidInfo_HideProgressDialogCalled()
        {
            _fakeModel.ChangePassword("OldValid", "Valid").Returns(true);
            _uut.ChangePassword("OldValid", "Valid", "Valid").Wait();
            _fakeView.Received().HideProgressDialog();
        }

        [Test]
        public void ChangePassword_InvalidInfo_PasswordNotChangedCalled()
        {
            _fakeModel.ChangePassword("OldValid", "Valid").Returns(true);
            _uut.ChangePassword("OldValid", "Invalid", "Invalid").Wait();
            _fakeView.Received().PasswordNotChanged();
        }
    }
}