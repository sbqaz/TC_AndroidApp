using NSubstitute;
using NUnit.Framework;
using TrafficControl.BLL.CreateUser;
using TrafficControl.DAL.RestSharp;

namespace TrafficControl.Test.Unit.CreateUser
{
    [TestFixture]
    public class CreateUserModelTests
    {
        private ITCApi _fakeApi;
        private CreateUserModel _uut;

        [SetUp]
        public void Init()
        {
            _fakeApi = Substitute.For<ITCApi>();
            _uut = new CreateUserModel(_fakeApi);
        }

        [Test]
        public void CreateUser_CorrectEmailParam_IsTrue()
        {
            _fakeApi.CreateUser("Email", "pw", "confpw", "fn", "ln", 2, "1234").Returns(true);
            Assert.IsTrue(_uut.CreateUser("Email", "pw", "confpw", "fn", "ln", "1234", "Administrator"));
        }

        [Test]
        public void CreateUser_WrongEmailParam_IsFalse()
        {
            _fakeApi.CreateUser("Email", "pw", "confpw", "fn", "ln", 2, "1234").Returns(true);
            Assert.IsFalse(_uut.CreateUser("wrong", "pw", "confpw", "fn", "ln", "1234", "Administrator"));
        }

        [Test]
        public void CreateUser_CorrectPasswordParam_IsTrue()
        {
            _fakeApi.CreateUser("Email", "pw", "confpw", "fn", "ln", 2, "1234").Returns(true);
            Assert.IsTrue(_uut.CreateUser("Email", "pw", "confpw", "fn", "ln", "1234", "Administrator"));
        }

        [Test]
        public void CreateUser_WrongPasswordParam_IsFalse()
        {
            _fakeApi.CreateUser("Email", "pw", "confpw", "fn", "ln", 2, "1234").Returns(true);
            Assert.IsFalse(_uut.CreateUser("Email", "wrong", "confpw", "fn", "ln", "1234", "Administrator"));
        }

        [Test]
        public void CreateUser_CorrectConfirmPasswordParam_IsTrue()
        {
            _fakeApi.CreateUser("Email", "pw", "confpw", "fn", "ln", 2, "1234").Returns(true);
            Assert.IsTrue(_uut.CreateUser("Email", "pw", "confpw", "fn", "ln", "1234", "Administrator"));
        }

        [Test]
        public void CreateUser_WrongConfirmPasswordParam_IsFalse()
        {
            _fakeApi.CreateUser("Email", "pw", "confpw", "fn", "ln", 2, "1234").Returns(true);
            Assert.IsFalse(_uut.CreateUser("wrong", "pw", "wrong", "fn", "ln", "1234", "Administrator"));
        }

        [Test]
        public void CreateUser_CorrectFirstNameParam_IsTrue()
        {
            _fakeApi.CreateUser("Email", "pw", "confpw", "fn", "ln", 2, "1234").Returns(true);
            Assert.IsTrue(_uut.CreateUser("Email", "pw", "confpw", "fn", "ln", "1234", "Administrator"));
        }

        [Test]
        public void CreateUser_WrongFirstNameParam_IsFalse()
        {
            _fakeApi.CreateUser("Email", "pw", "confpw", "fn", "ln", 2, "1234").Returns(true);
            Assert.IsFalse(_uut.CreateUser("wrong", "pw", "confpw", "wrong", "ln", "1234", "Administrator"));
        }

        [Test]
        public void CreateUser_CorrectLastNameParam_IsTrue()
        {
            _fakeApi.CreateUser("Email", "pw", "confpw", "fn", "ln", 2, "1234").Returns(true);
            Assert.IsTrue(_uut.CreateUser("Email", "pw", "confpw", "fn", "ln", "1234", "Administrator"));
        }

        [Test]
        public void CreateUser_WrongLastNameParam_IsFalse()
        {
            _fakeApi.CreateUser("Email", "pw", "confpw", "fn", "ln", 2, "1234").Returns(true);
            Assert.IsFalse(_uut.CreateUser("wrong", "pw", "confpw", "fn", "wrong", "1234", "Administrator"));
        }

        [Test]
        public void CreateUser_CorrectPhonenumberParam_IsTrue()
        {
            _fakeApi.CreateUser("Email", "pw", "confpw", "fn", "ln", 2, "1234").Returns(true);
            Assert.IsTrue(_uut.CreateUser("Email", "pw", "confpw", "fn", "ln", "1234", "Administrator"));
        }

        [Test]
        public void CreateUser_WrongPhonenumberParam_IsFalse()
        {
            _fakeApi.CreateUser("Email", "pw", "confpw", "fn", "ln", 2, "1234").Returns(true);
            Assert.IsFalse(_uut.CreateUser("wrong", "pw", "confpw", "fn", "ln", "12345", "Administrator"));
        }

        [Test]
        public void CreateUser_CalledWithTypeAdmin_ApiCalledWithCorrectTypeIdentifier()
        {
            _fakeApi.CreateUser("Email", "pw", "confpw", "fn", "ln", 2, "1234").Returns(true);
            Assert.IsTrue(_uut.CreateUser("Email", "pw", "confpw", "fn", "ln", "1234", "Administrator"));
        }

        [Test]
        public void CreateUser_CalledWithTypeWorker_ApiNotCalledWithAdminTypeIdentifier()
        {
            _fakeApi.CreateUser("Email", "pw", "confpw", "fn", "ln", 2, "1234").Returns(true);
            Assert.IsFalse(_uut.CreateUser("Email", "pw", "confpw", "fn", "ln", "1234", "Montør"));
        }

        [Test]
        public void CreateUser_CalledWithTypeUser_ApiNotCalledWithAdminTypeIdentifier()
        {
            _fakeApi.CreateUser("Email", "pw", "confpw", "fn", "ln", 2, "1234").Returns(true);
            Assert.IsFalse(_uut.CreateUser("Email", "pw", "confpw", "fn", "ln", "1234", "Randers Kommune"));
        }

        [Test]
        public void CreateUser_CalledWithTypeWorker_ApiCalledWithCorrectTypeIdentifier()
        {
            _fakeApi.CreateUser("Email", "pw", "confpw", "fn", "ln", 1, "1234").Returns(true);
            Assert.IsTrue(_uut.CreateUser("Email", "pw", "confpw", "fn", "ln", "1234", "Montør"));
        }

        [Test]
        public void CreateUser_CalledWithTypeAdmin_ApiNotCalledWithWorkerTypeIdentifier()
        {
            _fakeApi.CreateUser("Email", "pw", "confpw", "fn", "ln", 1, "1234").Returns(true);
            Assert.IsFalse(_uut.CreateUser("Email", "pw", "confpw", "fn", "ln", "1234", "Administrator"));
        }

        [Test]
        public void CreateUser_CalledWithTypeUser_ApiNotCalledWithWorkerTypeIdentifier()
        {
            _fakeApi.CreateUser("Email", "pw", "confpw", "fn", "ln", 1, "1234").Returns(true);
            Assert.IsFalse(_uut.CreateUser("Email", "pw", "confpw", "fn", "ln", "1234", "Randers Kommune"));
        }

        [Test]
        public void CreateUser_CalledWithTypeUser_ApiCalledWithCorrectTypeIdentifier()
        {
            _fakeApi.CreateUser("Email", "pw", "confpw", "fn", "ln", 0, "1234").Returns(true);
            Assert.IsTrue(_uut.CreateUser("Email", "pw", "confpw", "fn", "ln", "1234", "Randers Kommune"));
        }

        [Test]
        public void CreateUser_CalledWithTypeAdmin_ApiNotCalledWithUserTypeIdentifier()
        {
            _fakeApi.CreateUser("Email", "pw", "confpw", "fn", "ln", 0, "1234").Returns(true);
            Assert.IsFalse(_uut.CreateUser("Email", "pw", "confpw", "fn", "ln", "1234", "Administrator"));
        }

        [Test]
        public void CreateUser_CalledWithTypeWorker_ApiNotCalledWithUserTypeIdentifier()
        {
            _fakeApi.CreateUser("Email", "pw", "confpw", "fn", "ln", 0, "1234").Returns(true);
            Assert.IsFalse(_uut.CreateUser("Email", "pw", "confpw", "fn", "ln", "1234", "Montør"));
        }
    }
}