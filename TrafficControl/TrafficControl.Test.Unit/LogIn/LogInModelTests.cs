using System;
using NSubstitute;
using NUnit.Framework;
using TrafficControl.BLL.LogIn;
using TrafficControl.DAL.RestSharp;

namespace TrafficControl.Test.Unit.LogIn
{
    [TestFixture]
    public class LogInModelTests
    {
        private ITCApi _fakeTCApi;
        private LogInModel _uut;

        [SetUp]
        public void Init()
        {
            _fakeTCApi = Substitute.For<ITCApi>();
            _uut = new LogInModel(_fakeTCApi);
        }

        [Test]
        public void ValidateLogIn_CorrectEmailAndPassword_ReturnTrue()
        {
            _fakeTCApi.LogIn("CorrectEmail", "CorrectPassword").Returns(true);
            Assert.That(_uut.ValidateLogIn("CorrectEmail", "CorrectPassword"), Is.True);
        }

        [Test]
        public void ValidateLogIn_IncorrectEmail_ReturnFalse()
        {
            _fakeTCApi.LogIn("CorrectEmail", "CorrectPassword").Returns(true);
            Assert.That(_uut.ValidateLogIn("IncorrectEmail", "CorrectPassword"), Is.False);
        }

        [Test]
        public void ValidateLogIn_IncorrectPassword_ReturnFalse()
        {
            _fakeTCApi.LogIn("CorrectEmail", "CorrectPassword").Returns(true);
            Assert.That(_uut.ValidateLogIn("CorrectEmail", "IncorrectPassword"), Is.False);
        }

        [Test]
        public void ValidateLogIn_IncorrectEmailAndPassword_ReturnFalse()
        {
            _fakeTCApi.LogIn("CorrectEmail", "CorrectPassword").Returns(true);
            Assert.That(_uut.ValidateLogIn("IncorrectEmail", "IncorrectPassword"), Is.False);
        }

        [Test]
        public void ValidateLogIn_EmailIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _uut.ValidateLogIn(null, "NotNull"));
        }

        [Test]
        public void ValidateLogIn_PasswordIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _uut.ValidateLogIn("NotNull", null));
        }
    }
}