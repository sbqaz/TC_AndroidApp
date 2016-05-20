using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TrafficControl.BLL.Home;
using TrafficControl.DAL.RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.Test.Unit.Home
{
    [TestFixture]
    public class HomeModelTests
    {
        private ITCApi _fakeApi;
        private HomeModel _uut;

        [SetUp]
        public void Init()
        {
            _fakeApi = Substitute.For<ITCApi>();
            _uut = new HomeModel(_fakeApi);

            _fakeApi.GetCases().Returns(new List<Case>());
            _fakeApi.GetCases().Add(new Case()
            {
                Id = 1,
                Status = CaseStatus.Done,
                ErrorDescription = "String3",
                Time = new DateTime(2000),
                Installation = new Installation()
                {
                    Id = 1,
                    Name = "Street3",
                }
            });
            _fakeApi.GetCases().Add(new Case()
            {
                Id = 2,
                Status = CaseStatus.Started,
                ErrorDescription = "String4",
                Time = new DateTime(2000),
                Installation = new Installation()
                {
                    Id = 1,
                    Name = "Street4",
                }
            });
            _fakeApi.GetCases().Add(new Case()
            {
                Id = 3,
                Status = CaseStatus.Pending,
                ErrorDescription = "String4",
                Time = new DateTime(2000),
                Installation = new Installation()
                {
                    Id = 1,
                    Name = "Street4",
                }
            });
            _fakeApi.GetCases().Add(new Case()
            {
                Id = 4,
                Status = CaseStatus.Created,
                ErrorDescription = "String4",
                Time = new DateTime(2000),
                Installation = new Installation()
                {
                    Id = 1,
                    Name = "Street4",
                }
            });
            _fakeApi.GetCases().Add(new Case()
            {
                Id = 5,
                Status = CaseStatus.Created,
                ErrorDescription = "String4",
                Time = new DateTime(2001),
                Installation = new Installation()
                {
                    Id = 1,
                    Name = "Street4",
                }
            });

            _fakeApi.GetMyCases().Returns(new List<Case>());
            _fakeApi.GetMyCases().Add(new Case()
            {
                Id = 1,
                Status = CaseStatus.Done,
                ErrorDescription = "String3",
                Time = new DateTime(2000),
                Installation = new Installation()
                {
                    Id = 1,
                    Name = "Street3",
                }
            });
            _fakeApi.GetMyCases().Add(new Case()
            {
                Id = 2,
                Status = CaseStatus.Started,
                ErrorDescription = "String4",
                Time = new DateTime(2000),
                Installation = new Installation()
                {
                    Id = 1,
                    Name = "Street4",
                }
            });
            _fakeApi.GetMyCases().Add(new Case()
            {
                Id = 3,
                Status = CaseStatus.Pending,
                ErrorDescription = "String4",
                Time = new DateTime(2000),
                Installation = new Installation()
                {
                    Id = 1,
                    Name = "Street4",
                }
            });
            _fakeApi.GetMyCases().Add(new Case()
            {
                Id = 4,
                Status = CaseStatus.Created,
                ErrorDescription = "String4",
                Time = new DateTime(2000),
                Installation = new Installation()
                {
                    Id = 1,
                    Name = "Street4",
                }
            });
            _fakeApi.GetMyCases().Add(new Case()
            {
                Id = 5,
                Status = CaseStatus.Created,
                ErrorDescription = "String4",
                Time = new DateTime(2001),
                Installation = new Installation()
                {
                    Id = 1,
                    Name = "Street4",
                }
            });
        }

        [Test]
        public void Cases_OrderListByStatusAndTime_Element0HasId5()
        {
            Assert.That(_uut.Cases[0].Id, Is.EqualTo(5));
        }

        [Test]
        public void Cases_OrderListByStatusAndTime_Element1HasId4()
        {
            Assert.That(_uut.Cases[1].Id, Is.EqualTo(4));
        }

        [Test]
        public void Cases_OrderListByStatus_Element2HasId3()
        {
            Assert.That(_uut.Cases[2].Id, Is.EqualTo(3));
        }

        [Test]
        public void Cases_OrderListByStatus_Element3HasId2()
        {
            Assert.That(_uut.Cases[3].Id, Is.EqualTo(2));
        }

        [Test]
        public void Cases_OrderListByStatus_Element4HasId1()
        {
            Assert.That(_uut.MyCases[4].Id, Is.EqualTo(1));
        }

        [Test]
        public void MyCases_OrderListByStatusAndTime_Element0HasId5()
        {
            Assert.That(_uut.MyCases[0].Id, Is.EqualTo(5));
        }

        [Test]
        public void MyCases_OrderListByStatusAndTime_Element1HasId4()
        {
            Assert.That(_uut.MyCases[1].Id, Is.EqualTo(4));
        }

        [Test]
        public void MyCases_OrderListByStatus_Element2HasId3()
        {
            Assert.That(_uut.MyCases[2].Id, Is.EqualTo(3));
        }

        [Test]
        public void MyCases_OrderListByStatus_Element3HasId2()
        {
            Assert.That(_uut.MyCases[3].Id, Is.EqualTo(2));
        }

        [Test]
        public void MyCases_OrderListByStatus_Element4HasId1()
        {
            Assert.That(_uut.MyCases[4].Id, Is.EqualTo(1));
        }

    }
}