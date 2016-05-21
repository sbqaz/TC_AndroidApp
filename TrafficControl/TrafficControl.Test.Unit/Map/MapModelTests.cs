using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TrafficControl.BLL.Map;
using TrafficControl.DAL.RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.Test.Unit.Map
{
    [TestFixture]
    public class MapModelTests
    {
        private ITCApi _fakeApi;
        private MapModel _uut;
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

            _uut = new MapModel(_fakeApi);
        }

        [Test]
        public void Installations_ConsistentWithApi()
        {
            Assert.That(_uut.Installations, Is.EqualTo(_installations));

        }

    }
}