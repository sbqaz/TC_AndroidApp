using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TrafficControl.BLL.Map;
using TrafficControl.DAL.RestSharp.Types;
using TrafficControl.GUI.Map;

namespace TrafficControl.Test.Unit.Map
{
    [TestFixture]
    public class MapPresenterTests
    {
        private IMapModel _fakeModel;
        private IMapView _fakeView;
        private MapPresenter _uut;

        [SetUp]
        public void Init()
        {
            _fakeView = Substitute.For<IMapView>();
            _fakeModel = Substitute.For<IMapModel>();
            _uut = new MapPresenter(_fakeView, _fakeModel);
        }

        [Test]
        public void MapReady_SetCameraDefaultPositionCalled()
        {
            _uut.MapReady();
            _fakeView.Received().SetCameraDefaultPosition();
        }

        [Test]
        public void MapReady_ModelHas0Installations_AddMapMarkerIsNotCalled()
        {
            _fakeModel.Installations.Returns(new List<Installation>());
            _uut.MapReady();
            _fakeView.DidNotReceive().AddMapMarker(Arg.Any<Installation>());
        }

        [Test]
        public void MapReady_ModelHas10Installations_AddMapMarkerIsCalled10Times()
        {
            _fakeModel.Installations.Returns(new Installation[10]);
            _uut.MapReady();
            _fakeView.Received(10).AddMapMarker(Arg.Any<Installation>());
        }

        [Test]
        public void MapReady_ModelHas1Installations_AddMapMarkerIsCalled1Time()
        {
            _fakeModel.Installations.Returns(new Installation[1]);
            _uut.MapReady();
            _fakeView.Received(1).AddMapMarker(Arg.Any<Installation>());
        }
    }
}