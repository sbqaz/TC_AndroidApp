using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TrafficControl.BLL;
using TrafficControl.BLL.Home;
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
        }

        [Test]
        public void Ctor_PressenterAttachesToObservableModel()
        {
            _fakeModel.Received().Attach(_uut);
        }

        [Test]
        public void GetCases_ReturnsModelCases()
        {
            _fakeModel.Cases.Returns(new List<Case>());
            _fakeModel.MyCases.Returns(new List<Case>());
            _fakeModel.Cases.Add(new Case("a", 1, DateTime.Today, Case.States.Open));
            _fakeModel.Cases.Add(new Case("b", 2, DateTime.Today, Case.States.Open));
            _fakeModel.Cases.Add(new Case("c", 3, DateTime.Today, Case.States.Open));

            Assert.That(_uut.GetCases(), Is.EqualTo(_fakeModel.Cases));
        }

        [Test]
        public void GetMyCases_ReturnsModelMyCases()
        {
            _fakeModel.Cases.Returns(new List<Case>());
            _fakeModel.MyCases.Returns(new List<Case>());
            _fakeModel.MyCases.Add(new Case("aa", 11, DateTime.Today, Case.States.Closed));
            _fakeModel.MyCases.Add(new Case("bb", 22, DateTime.Today, Case.States.Closed));
            _fakeModel.MyCases.Add(new Case("cc", 33, DateTime.Today, Case.States.Closed));

            Assert.That(_uut.GetMyCases(), Is.EqualTo(_fakeModel.MyCases));
        }

        [Test]
        public void Update_ViewIsNotNull_UpdateCaseViewCalled()
        {
            _uut.Update(_fakeModel);
            _fakeView.Received().UpdateCaseView();
        }

        [Test]
        public void Update_ViewIsNull_UpdateCaseViewIsNotCalled()
        {
            _uut.OnDestroy();
            _uut.Update(_fakeModel);
            _fakeView.DidNotReceive().UpdateCaseView();
        }
    }
}