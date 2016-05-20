using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TrafficControl.BLL;
using TrafficControl.BLL.Home;
using TrafficControl.DAL.RestSharp;
using TrafficControl.DAL.RestSharp.Types;
using TrafficControl.GUI.Home;

namespace TrafficControl.Test.Unit.Home
{
    [TestFixture]
    public class HomePresenterTests
    {
        private IHomeView _fakeView;
        private IHomeModel _fakeModel;
        private HomePresenter _uut;

        [SetUp]
        public void Init()
        {
            _fakeView = Substitute.For<IHomeView>();
            _fakeModel = Substitute.For<IHomeModel>();
            _uut = new HomePresenter(_fakeView, _fakeModel);


            _fakeModel.Cases.Returns(new List<Case>());
            _fakeModel.Cases.Add(new Case()
            {
                Id = 1,
                Status = CaseStatus.Created,
                ErrorDescription = "String",
                Installation = new Installation()
                {
                    Id = 1,
                    Name = "Street",
                }
            });
            _fakeModel.Cases.Add(new Case()
            {
                Id = 2,
                Status = CaseStatus.Pending,
                ErrorDescription = "String2",
                Installation = new Installation()
                {
                    Id = 1,
                    Name = "Street2",
                }
            });

            _fakeModel.MyCases.Returns(new List<Case>());
            _fakeModel.MyCases.Add(new Case()
            {
                Id = 3,
                Status = CaseStatus.Created,
                ErrorDescription = "String3",
                Installation = new Installation()
                {
                    Id = 1,
                    Name = "Street3",
                }
            });
            _fakeModel.MyCases.Add(new Case()
            {
                Id = 4,
                Status = CaseStatus.Pending,
                ErrorDescription = "String4",
                Installation = new Installation()
                {
                    Id = 1,
                    Name = "Street4",
                }
            });
        }

        [Test]
        public void GetCases_ReturnsModelCases()
        {
            Assert.That(_uut.GetCases(), Is.EqualTo(_fakeModel.Cases));
        }

        [Test]
        public void GetCases_NoExceptionThrown()
        {
            Assert.DoesNotThrow(() => _uut.GetCases());
        }

        [Test]
        public void GetCasesAsync_ReturnsModelCases()
        {
            Assert.That(_uut.GetCasesAsync().Result, Is.EqualTo(_fakeModel.Cases));
        }

        [Test]
        public void GetCasesAsync_NoExceptionThrown()
        {
            Assert.DoesNotThrow(() => _uut.GetCasesAsync().Wait());
        }

        [Test]
        public void GetMyCases_ReturnsModelMyCases()
        {
            Assert.That(_uut.GetMyCases(), Is.EqualTo(_fakeModel.MyCases));
        }

        [Test]
        public void GetMyCases_NoExceptionThrown()
        {
            Assert.DoesNotThrow(() => _uut.GetMyCases());
        }
    }
}