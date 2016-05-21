using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TrafficControl.BLL.CreateCase;
using TrafficControl.DAL.RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.Test.Unit.CreateCase
{
    [TestFixture]
    public class CreateCaseModelTests
    {
        private ITCApi _fakeApi;
        private CreateCaseModel _uut;
        private List<Installation> _installations;

        [SetUp]
        public void Init()
        {
            _fakeApi = Substitute.For<ITCApi>();

            
            _installations = new List<Installation>
            {
                new Installation()
                {
                    Id = 1,
                    Name = "First",
                    Position = new Position()
                    {
                        Id = 1,
                        Latitude = 10.1,
                        Longtitude = 50.2
                    },
                    Status = 0
                },
                new Installation()
                {
                    Id = 2,
                    Name = "Second",
                    Position = new Position()
                    {
                        Id = 2,
                        Latitude = 20.1,
                        Longtitude = 60.2
                    },
                    Status = 1
                },
                new Installation()
                {
                    Id = 3,
                    Name = "Third",
                    Position = new Position()
                    {
                        Id = 3,
                        Latitude = 30.1,
                        Longtitude = 70.2
                    },
                    Status = 2
                }
            };
            _fakeApi.GetInstallations().Returns(_installations);

            _uut = new CreateCaseModel(_fakeApi);
        }

        [Test]
        public void FetchData_Informer0StringIsCorrect()
        {
            _uut.FetchData();
            StringAssert.Contains("politiet", _uut.Informers[0].ToLower());
        }

        [Test]
        public void FetchData_Informer1StringIsCorrect()
        {
            _uut.FetchData();
            StringAssert.Contains("kommunen", _uut.Informers[1].ToLower());
        }

        [Test]
        public void FetchData_Informer2StringIsCorrect()
        {
            _uut.FetchData();
            StringAssert.Contains("borger", _uut.Informers[2].ToLower());
        }

        [Test]
        public void FetchData_Informer3StringIsCorrect()
        {
            _uut.FetchData();
            StringAssert.Contains("montør", _uut.Informers[3].ToLower());
        }

        [Test]
        public void FetchData_FirstInstallationHasId1()
        {
            _uut.FetchData();
            Assert.That(_uut.Installations["First"], Is.EqualTo(1));
        }

        [Test]
        public void FetchData_SecondInstallationHasId1()
        {
            _uut.FetchData();
            Assert.That(_uut.Installations["Second"], Is.EqualTo(2));
        }

        [Test]
        public void FetchData_ThirdInstallationHasId1()
        {
            _uut.FetchData();
            Assert.That(_uut.Installations["Third"], Is.EqualTo(3));
        }

        [Test]
        public void CreateCase_WithUndefinedInformer_ApiCreateCaseCalledWithCorrectParameter()
        {
            _fakeApi.CreateCase(1, ObserverSelection.Undefined, "").Returns(true);
            _uut.FetchData();
            Assert.IsTrue(_uut.CreateCase("First","somethingUndefined", ""));
        }

        [Test]
        public void CreateCase_WithOtherThanUndefinedInformer_ApiCreateCaseNotCalledWithUndefinedParameter()
        {
            _fakeApi.CreateCase(1, ObserverSelection.Undefined, "").Returns(true);
            _uut.FetchData();
            Assert.IsFalse(_uut.CreateCase("First", "Politiet", ""));
            Assert.IsFalse(_uut.CreateCase("First", "Kommunen", ""));
            Assert.IsFalse(_uut.CreateCase("First", "Borger", ""));
            Assert.IsFalse(_uut.CreateCase("First", "Montør", ""));
        }

        [Test]
        public void CreateCase_WithPoliceInformer_ApiCreateCaseCalledWithCorrectParameter()
        {
            _fakeApi.CreateCase(1, ObserverSelection.Police, "").Returns(true);
            _uut.FetchData();
            Assert.IsTrue(_uut.CreateCase("First", "Politiet", ""));
        }

        [Test]
        public void CreateCase_WithOtherThanPoliceInformer_ApiCreateCaseNotCalledWithPoliceParameter()
        {
            _fakeApi.CreateCase(1, ObserverSelection.Police, "").Returns(true);
            _uut.FetchData();
            Assert.IsFalse(_uut.CreateCase("First", "somethingUndefined", ""));
            Assert.IsFalse(_uut.CreateCase("First", "Kommunen", ""));
            Assert.IsFalse(_uut.CreateCase("First", "Borger", ""));
            Assert.IsFalse(_uut.CreateCase("First", "Montør", ""));
        }

        [Test]
        public void CreateCase_WithUserInformer_ApiCreateCaseCalledWithCorrectParameter()
        {
            _fakeApi.CreateCase(1, ObserverSelection.User, "").Returns(true);
            _uut.FetchData();
            Assert.IsTrue(_uut.CreateCase("First", "Kommunen", ""));
        }

        [Test]
        public void CreateCase_WithOtherThanUserInformer_ApiCreateCaseNotCalledWithUserParameter()
        {
            _fakeApi.CreateCase(1, ObserverSelection.User, "").Returns(true);
            _uut.FetchData();
            Assert.IsFalse(_uut.CreateCase("First", "somethingUndefined", ""));
            Assert.IsFalse(_uut.CreateCase("First", "Politiet", ""));
            Assert.IsFalse(_uut.CreateCase("First", "Borger", ""));
            Assert.IsFalse(_uut.CreateCase("First", "Montør", ""));
        }

        [Test]
        public void CreateCase_WithThirdPartInformer_ApiCreateCaseCalledWithCorrectParameter()
        {
            _fakeApi.CreateCase(1, ObserverSelection.ThirdPart, "").Returns(true);
            _uut.FetchData();
            Assert.IsTrue(_uut.CreateCase("First", "Borger", ""));
        }

        [Test]
        public void CreateCase_WithOtherThanThirdPartInformer_ApiCreateCaseNotCalledWithThirdPartParameter()
        {
            _fakeApi.CreateCase(1, ObserverSelection.ThirdPart, "").Returns(true);
            _uut.FetchData();
            Assert.IsFalse(_uut.CreateCase("First", "somethingUndefined", ""));
            Assert.IsFalse(_uut.CreateCase("First", "Politiet", ""));
            Assert.IsFalse(_uut.CreateCase("First", "Kommunen", ""));
            Assert.IsFalse(_uut.CreateCase("First", "Montør", ""));
        }

        [Test]
        public void CreateCase_WithOwnInformer_ApiCreateCaseCalledWithCorrectParameter()
        {
            _fakeApi.CreateCase(1, ObserverSelection.Own, "").Returns(true);
            _uut.FetchData();
            Assert.IsTrue(_uut.CreateCase("First", "Montør", ""));
        }

        [Test]
        public void CreateCase_WithOtherThanOwnInformer_ApiCreateCaseNotCalledWithOwnParameter()
        {
            _fakeApi.CreateCase(1, ObserverSelection.Own, "").Returns(true);
            _uut.FetchData();
            Assert.IsFalse(_uut.CreateCase("First", "somethingUndefined", ""));
            Assert.IsFalse(_uut.CreateCase("First", "Politiet", ""));
            Assert.IsFalse(_uut.CreateCase("First", "Kommunen", ""));
            Assert.IsFalse(_uut.CreateCase("First", "Borger", ""));
        }
    }
}