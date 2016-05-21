using NSubstitute;
using NUnit.Framework;
using TrafficControl.BLL.CreateUser;
using TrafficControl.DAL.RestSharp;

namespace TrafficControl.Test.Unit.CreateUser
{
    [TestFixture]
    public class CreatePasswordModelTests
    {
        private ITCApi _fakeApi;
        private ChangePasswordModel _uut;

        [SetUp]
        public void Init()
        {
            _fakeApi = Substitute.For<ITCApi>();
            _uut = new ChangePasswordModel(_fakeApi);
        }

        [Test]
        public void ChangePassword_ApiCalledCorrectly()
        {
            _fakeApi.ChangePassword("old", "new", "new").Returns(true);
            Assert.IsTrue(_uut.ChangePassword("old", "new"));
        }

        [Test]
        public void ChangePassword_WrongOldPw_ApiCalledCorrectly()
        {
            _fakeApi.ChangePassword("old", "new", "new").Returns(true);
            Assert.IsFalse(_uut.ChangePassword("wrong", "new"));
        }

        [Test]
        public void ChangePassword_WrongNewPw_ApiCalledCorrectly()
        {
            _fakeApi.ChangePassword("old", "new", "new").Returns(true);
            Assert.IsFalse(_uut.ChangePassword("old", "wrong"));
        }
    }
}