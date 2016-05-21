using NSubstitute;
using NUnit.Framework;
using TrafficControl.BLL.CreateUser;
using TrafficControl.GUI.CreateUser;

namespace TrafficControl.Test.Unit.CreateUser
{
    [TestFixture]
    public class CreateUserPresenterTests
    {
        private ICreateUserModel _fakeModel;
        private ICreateUserView _fakeView;
        private CreateUserPresenter _uut;

        [SetUp]
        public void Init()
        {
            _fakeView = Substitute.For<ICreateUserView>();
            _fakeModel = Substitute.For<ICreateUserModel>();
            _uut = new CreateUserPresenter(_fakeView, _fakeModel);
        }

        [Test]
        public void OnCreateUserClick_EmailNull_ShowMissingInfoErrorCalled()
        {
            _uut.OnCreateUserClick(null, "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void OnCreateUserClick_EmailNull_SetEmailErrorCalled()
        {
            _uut.OnCreateUserClick(null, "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().SetEmailError();
        }

        [Test]
        public void OnCreateUserClick_EmailEmpty_ShowMissingInfoErrorCalled()
        {
            _uut.OnCreateUserClick("", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void OnCreateUserClick_EmailEmpty_SetEmailErrorCalled()
        {
            _uut.OnCreateUserClick("", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().SetEmailError();
        }

        [Test]
        public void OnCreateUserClick_PasswordNull_ShowMissingInfoErrorCalled()
        {
            _uut.OnCreateUserClick("NotEmpty", null, "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void OnCreateUserClick_PasswordNull_SetPasswordErrorCalled()
        {
            _uut.OnCreateUserClick("NotEmpty", null, "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().SetPasswordError();
        }

        [Test]
        public void OnCreateUserClick_PasswordEmpty_ShowMissingInfoErrorCalled()
        {
            _uut.OnCreateUserClick("NotEmpty", "", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void OnCreateUserClick_PasswordEmpty_SetPasswordErrorCalled()
        {
            _uut.OnCreateUserClick("NotEmpty", "", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().SetPasswordError();
        }

        [Test]
        public void OnCreateUserClick_ConfirmPasswordNull_ShowMissingInfoErrorCalled()
        {
            _uut.OnCreateUserClick("NotEmpty", "NotEmpty", null, "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void OnCreateUserClick_ConfirmPasswordNull_SetConfirmPasswordErrorCalled()
        {
            _uut.OnCreateUserClick("NotEmpty", "NotEmpty", null, "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().SetConfirmPasswordError();
        }

        [Test]
        public void OnCreateUserClick_ConfirmPasswordEmpty_ShowMissingInfoErrorCalled()
        {
            _uut.OnCreateUserClick("NotEmpty", "NotEmpty", "", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void OnCreateUserClick_ConfirmPasswordEmpty_SetConfirmPasswordErrorCalled()
        {
            _uut.OnCreateUserClick("NotEmpty", "NotEmpty", "", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().SetConfirmPasswordError();
        }

        [Test]
        public void OnCreateUserClick_FirstNameNull_ShowMissingInfoErrorCalled()
        {
            _uut.OnCreateUserClick("NotEmpty", "NotEmpty", "NotEmpty", null, "NotEmpty", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void OnCreateUserClick_FirstNameNull_SetFirstNameErrorCalled()
        {
            _uut.OnCreateUserClick("NotEmpty", "NotEmpty", "NotEmpty", null, "NotEmpty", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().SetFirstNameError();
        }

        [Test]
        public void OnCreateUserClick_FirstNameEmpty_ShowMissingInfoErrorCalled()
        {
            _uut.OnCreateUserClick("NotEmpty", "NotEmpty", "NotEmpty", "", "NotEmpty", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void OnCreateUserClick_FirstNameEmpty_SetFirstNameErrorCalled()
        {
            _uut.OnCreateUserClick("NotEmpty", "NotEmpty", "NotEmpty", "", "NotEmpty", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().SetFirstNameError();
        }

        [Test]
        public void OnCreateUserClick_LastNameNull_ShowMissingInfoErrorCalled()
        {
            _uut.OnCreateUserClick("NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", null, "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void OnCreateUserClick_LastNameNull_SetLastNameErrorCalled()
        {
            _uut.OnCreateUserClick("NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", null, "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().SetLastNameError();
        }

        [Test]
        public void OnCreateUserClick_LastNameEmpty_ShowMissingInfoErrorCalled()
        {
            _uut.OnCreateUserClick("NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", "", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void OnCreateUserClick_LastNameEmpty_SetLastNameErrorCalled()
        {
            _uut.OnCreateUserClick("NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", "", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().SetLastNameError();
        }

        [Test]
        public void OnCreateUserClick_PhonenumberNull_ShowMissingInfoErrorCalled()
        {
            _uut.OnCreateUserClick("NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", null,"NotEmpty").Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void OnCreateUserClick_PhonenumberNull_SetPhoneNumberErrorCalled()
        {
            _uut.OnCreateUserClick("NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", null,"NotEmpty").Wait();
            _fakeView.Received().SetPhoneNumberError();
        }

        [Test]
        public void OnCreateUserClick_PhonenumberEmpty_ShowMissingInfoErrorCalled()
        {
            _uut.OnCreateUserClick("NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", "", "NotEmpty").Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void OnCreateUserClick_PhonenumberEmpty_SetPhoneNumberErrorCalled()
        {
            _uut.OnCreateUserClick("NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty", "","NotEmpty").Wait();
            _fakeView.Received().SetPhoneNumberError();
        }

        [Test]
        public void OnCreateUserClick_PasswordAndConfirmPasswordAreDifferent_ConfirmPasswordNotMatchingErrorCalled()
        {
            _uut.OnCreateUserClick("NotEmpty", "Not", "TheSame", "NotEmpty", "NotEmpty", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().ConfirmPasswordNotMatchingError();
        }

        [Test]
        public void OnCreateUserClick_ValidInfo_ShowProgressDialogCalled()
        {
            _fakeModel.CreateUser("Valid", "Valid", "Valid", "Valid", "Valid", "Valid", "Valid").Returns(true);
            _uut.OnCreateUserClick("Valid", "Valid", "Valid", "Valid", "Valid", "Valid", "Valid").Wait();
            _fakeView.Received().ShowProgressDialog();
        }

        [Test]
        public void OnCreateUserClick_ValidInfo_HideProgressDialogCalled()
        {
            _fakeModel.CreateUser("Valid", "Valid", "Valid", "Valid", "Valid", "Valid", "Valid").Returns(true);
            _uut.OnCreateUserClick("Valid", "Valid", "Valid", "Valid", "Valid", "Valid", "Valid").Wait();
            _fakeView.Received().HideProgressDialog();
        }

        [Test]
        public void OnCreateUserClick_ValidInfo_UserCreatedCalled()
        {
            _fakeModel.CreateUser("Valid", "Valid", "Valid", "Valid", "Valid", "Valid", "Valid").Returns(true);
            _uut.OnCreateUserClick("Valid", "Valid", "Valid", "Valid", "Valid", "Valid", "Valid").Wait();
            _fakeView.Received().UserCreated();
        }

        [Test]
        public void OnCreateUserClick_InvalidInfo_HideProgressDialogCalled()
        {
            _fakeModel.CreateUser("Valid", "Valid", "Valid", "Valid", "Valid", "Valid", "Valid").Returns(true);
            _uut.OnCreateUserClick("Invalid", "Invalid", "Invalid", "Invalid", "Invalid", "Invalid", "Invalid").Wait();
            _fakeView.Received().HideProgressDialog();
        }

        [Test]
        public void OnCreateUserClick_InvalidInfo_UserNotCreatedCalled()
        {
            _fakeModel.CreateUser("Valid", "Valid", "Valid", "Valid", "Valid", "Valid", "Valid").Returns(true);
            _uut.OnCreateUserClick("Invalid", "Invalid", "Invalid", "Invalid", "Invalid", "Invalid", "Invalid").Wait();
            _fakeView.Received().UserNotCreated();
        }
    }
}