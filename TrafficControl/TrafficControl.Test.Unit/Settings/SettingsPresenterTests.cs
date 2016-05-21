using NSubstitute;
using NUnit.Framework;
using TrafficControl.BLL.Home;
using TrafficControl.BLL.Settings;
using TrafficControl.GUI.Settings;

namespace TrafficControl.Test.Unit.Settings
{
    [TestFixture]
    public class SettingsPresenterTests
    {
        private ISettingsView _fakeView;
        private ISettingsModel _fakeModel;
        private IUserPreference _fakeUserPreference;
        private SettingsPresenter _uut;

        [SetUp]
        public void Init()
        {
            _fakeView = Substitute.For<ISettingsView>();
            _fakeModel = Substitute.For<ISettingsModel>();
            _fakeUserPreference = Substitute.For<IUserPreference>();
            _uut = new SettingsPresenter(_fakeView, _fakeModel, _fakeUserPreference);
        }

        [Test]
        public void CreateUser_NavigatesToCreateUser()
        {
            _uut.CreateUser();
            _fakeView.Received().NavigateToCreateUser();
        }

        [Test]
        public void ChangePassword_NavigatesToChangePassword()
        {
            _uut.ChangePassword();
            _fakeView.Received().NavigateToChangePassword();
        }

        [Test]
        public void FirstNameChanged_UserPreferenceSetFirstName()
        {
            _uut.FirstNameChanged("FirstNameChanged");
            _fakeUserPreference.Received().SetFirstName("FirstNameChanged");
        }

        [Test]
        public void LastNameChanged_UserPreferenceSetLastName()
        {
            _uut.LastNameChanged("LastNameChanged");
            _fakeUserPreference.Received().SetLastName("LastNameChanged");
        }

        [Test]
        public void PhonenumberChanged_UserPreferenceSetPhonenumber()
        {
            _uut.PhonenumberChanged("12341234");
            _fakeUserPreference.Received().SetPhonenumber("12341234");
        }

        [Test]
        public void NotifyEmailChanged_SetToTrue_UserPreferenceSetNotifyEmail()
        {
            _uut.NotifyEmailChanged(true);
            _fakeUserPreference.Received().SetNotifyEmail(true);
        }

        [Test]
        public void NotifyEmailChanged_SetToFalse_UserPreferenceSetNotifyEmail()
        {
            _uut.NotifyEmailChanged(false);
            _fakeUserPreference.Received().SetNotifyEmail(false);
        }

        [Test]
        public void NotifySmsChanged_SetToTrue_UserPreferenceSetNotifySms()
        {
            _uut.NotifySmsChanged(true);
            _fakeUserPreference.Received().SetNotifySms(true);
        }

        [Test]
        public void NotifySmsChanged_SetToFalse_UserPreferenceSetNotifySms()
        {
            _uut.NotifySmsChanged(false);
            _fakeUserPreference.Received().SetNotifySms(false);
        }
    }
}