using System.Threading;
using NSubstitute;
using NUnit.Framework;
using TrafficControl.BLL.Home;
using TrafficControl.DAL.RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.Test.Unit.Home
{
    [TestFixture]
    public class UserPreferenceTests
    {
        private ITCApi _fakeApi;
        private UserPreference _uut;

        [SetUp]
        public void Init()
        {
            _fakeApi = Substitute.For<ITCApi>();
            _uut = new UserPreference(_fakeApi);

            _fakeApi.UpdateUser(Arg.Any<User>()).Returns(true);
            _fakeApi.GetUser().Returns(new User()
            {
                Email = "email",
                EmailNotification = true,
                SMSNotification = true,
                FirstName = "First",
                LastName = "Last",
                Id = "1",
                Number = "12341234",
                Role = 0
            });
        }

        [Test]
        public void GetUserFirstName_FirstNameIsNotNull_ReturnsFirst()
        {
            _uut.SetUserPreference();
            Assert.That(_uut.GetUserFirstName(), Is.EqualTo("First"));
        }

        [Test]
        public void GetUserFirstName_FirstNameIsNull_ReturnsNONAME()
        {
            _fakeApi.GetUser().Returns(new User());
            _uut.SetUserPreference();
            Assert.That(_uut.GetUserFirstName(), Is.EqualTo("_NO_NAME_"));
        }

        [Test]
        public void GetUserLastName_LastNameIsNotNull_ReturnsLast()
        {
            _uut.SetUserPreference();
            Assert.That(_uut.GetUserLastName(), Is.EqualTo("Last"));
        }

        [Test]
        public void GetUserLastName_LastNameIsNull_ReturnsNONAME()
        {
            _fakeApi.GetUser().Returns(new User());
            _uut.SetUserPreference();
            Assert.That(_uut.GetUserLastName(), Is.EqualTo("_NO_NAME_"));
        }

        [Test]
        public void GetPhonenumber_PhonenumberIsNotNull_Returns12341234()
        {
            _uut.SetUserPreference();
            Assert.That(_uut.GetPhonenumber(), Is.EqualTo("12341234"));
        }

        [Test]
        public void GetPhonenumber_PhonenumberIsNull_ReturnsNOPHONENUMBER()
        {
            _fakeApi.GetUser().Returns(new User());
            _uut.SetUserPreference();
            Assert.That(_uut.GetPhonenumber(), Is.EqualTo("_NO_PHONENUMBER_"));
        }

        [Test]
        public void GetEmailNotification_ReturnsTrue()
        {
            _uut.SetUserPreference();
            Assert.That(_uut.GetEmailNotification(), Is.True);
        }

        [Test]
        public void GetSmsNotification_ReturnsTrue()
        {
            _uut.SetUserPreference();
            Assert.That(_uut.GetSmsNotification(), Is.True);
        }

        [Test]
        public void SetFirstName_FirstNameChangedToNewFirst()
        {
            _uut.SetUserPreference();
            _uut.SetFirstName("NewFirst");
            Assert.That(_uut.GetUserFirstName(), Is.EqualTo("NewFirst"));
        }

        [Test]
        public void SetFirstName_UpdateUserCalled()
        {
            _uut.SetUserPreference();
            _uut.SetFirstName("NewFirst");
            Thread.Sleep(1);
            _fakeApi.Received().UpdateUser(Arg.Any<User>());
        }
        
        [Test]
        public void SetLastName_LastNameChangedToNewLast()
        {
            _uut.SetUserPreference();
            _uut.SetLastName("NewLast");
            Assert.That(_uut.GetUserLastName(), Is.EqualTo("NewLast"));
        }

        [Test]
        public void SetLastName_UpdateUserCalled()
        {
            _uut.SetUserPreference();
            _uut.SetLastName("NewLast");
            Thread.Sleep(1);
            _fakeApi.Received().UpdateUser(Arg.Any<User>());
        }

        [Test]
        public void SetPhonenumber_PhonenumberChangedTo1234()
        {
            _uut.SetUserPreference();
            _uut.SetPhonenumber("1234");
            Assert.That(_uut.GetPhonenumber(), Is.EqualTo("1234"));
        }

        [Test]
        public void SetPhonenumber_UpdateUserCalled()
        {
            _uut.SetUserPreference();
            _uut.SetPhonenumber("1234");
            Thread.Sleep(1);
            _fakeApi.Received().UpdateUser(Arg.Any<User>());
        }

        [Test]
        public void SetNotifyEmail_EmailNotificationChangedToFalse()
        {
            _uut.SetUserPreference();
            _uut.SetNotifyEmail(false);
            Assert.That(_uut.GetEmailNotification(), Is.False);
        }

        [Test]
        public void SetNotifyEmail_UpdateUserCalled()
        {
            _uut.SetUserPreference();
            _uut.SetNotifyEmail(false);
            Thread.Sleep(1);
            _fakeApi.Received().UpdateUser(Arg.Any<User>());
        }

        [Test]
        public void SetNotifySms_SmsNotificationChangedToFalse()
        {
            _uut.SetUserPreference();
            _uut.SetNotifySms(false);
            Assert.That(_uut.GetSmsNotification, Is.False);
        }

        [Test]
        public void SetNotifySms_UpdateUserCalled()
        {
            _uut.SetUserPreference();
            _uut.SetNotifySms(false);
            Thread.Sleep(1);
            _fakeApi.Received().UpdateUser(Arg.Any<User>());
        }
    }
}