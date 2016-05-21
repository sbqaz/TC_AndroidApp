using NSubstitute;
using NUnit.Framework;
using TrafficControl.BLL.Cases;
using TrafficControl.DAL.RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.Test.Unit.Cases
{
    [TestFixture]
    public class CaseModelTests
    {
        private ITCApi _fakeApi;
        private CaseModel _uut;

        [SetUp]
        public void Init()
        {
            _fakeApi = Substitute.For<ITCApi>();
            _uut = new CaseModel(_fakeApi);
        }

        [Test]
        public void GetCase_CorrectId_ReturnCaseFromApi()
        {
            var testCase = new Case
            {
                Id = 1,
            };

            _fakeApi.GetCase(1).Returns(testCase);

            Assert.That(_uut.GetCase(1), Is.EqualTo(testCase));
        }

        [Test]
        public void GetCase_WrongId_DoesntReturnCaseFromApi()
        {
            var testCase = new Case
            {
                Id = 1,
            };

            _fakeApi.GetCase(1).Returns(testCase);

            Assert.That(_uut.GetCase(2), Is.Not.EqualTo(testCase));
        }

        [Test]
        public void ClaimCase_CorrectId_IsTrue()
        {
            _fakeApi.ClaimCase(1).Returns(true);
            Assert.IsTrue(_uut.ClaimCase(1));
        }

        [Test]
        public void ClaimCase_WrongId_IsFalse()
        {
            _fakeApi.ClaimCase(1).Returns(true);
            Assert.IsFalse(_uut.ClaimCase(2));
        }

        [Test]
        public void UpdateCase_UpdatesCase()
        {
            var testCase = new Case
            {
                Id = 1,
            };

            _fakeApi.UpdateCase(testCase).Returns(true);

            Assert.IsTrue(_uut.UpdateCase(testCase));
        }

        [Test]
        public void UpdateCase_UpdatesCaseFails()
        {
            var testCase = new Case
            {
                Id = 1,
            };

            _fakeApi.UpdateCase(testCase).Returns(false);

            Assert.IsFalse(_uut.UpdateCase(testCase));
        }

    }
}