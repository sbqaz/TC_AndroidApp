using NSubstitute;
using NUnit.Framework;
using TrafficControl.GUI.Menu;

namespace TrafficControl.Test.Unit.Menu
{
    [TestFixture]
    public class MenuPresenterTests
    {
        private IMenuView _fakeView;
        private MenuPresenter _uut;

        [SetUp]
        public void Init()
        {
            _fakeView = Substitute.For<IMenuView>();
            _uut = new MenuPresenter(_fakeView);
        }

        [Test]
        public void GetMenuItems_FirstItemIsHome()
        {
            StringAssert.Contains("hjem", _uut.GetMenuItems()[0].ToLower());
        }

        [Test]
        public void GetMenuItems_SecondItemIsHome()
        {
            StringAssert.Contains("sager", _uut.GetMenuItems()[1].ToLower());
        }

        [Test]
        public void GetMenuItems_ThirdItemIsHome()
        {
            StringAssert.Contains("lyskryds", _uut.GetMenuItems()[2].ToLower());
        }

        [Test]
        public void GetMenuItems_FourthItemIsHome()
        {
            StringAssert.Contains("kort", _uut.GetMenuItems()[3].ToLower());
        }

        [Test]
        public void GetMenuItems_FithItemIsSettings()
        {
            StringAssert.Contains("indstillinger", _uut.GetMenuItems()[4].ToLower());
        }

        [Test]
        public void LeftMenuItemClicked_Position0_OnHomeClickedCalled()
        {
            _uut.LeftMenuItemClicked(0);
            _fakeView.Received().OnHomeClicked();
        }

        [Test]
        public void LeftMenuItemClicked_Position2_OnHomeClickedCalled()
        {
            _uut.LeftMenuItemClicked(2);
            _fakeView.Received().OnTrafficLightClicked();
        }

        [Test]
        public void LeftMenuItemClicked_Position3_OnHomeClickedCalled()
        {
            _uut.LeftMenuItemClicked(3);
            _fakeView.Received().OnMapClicked();
        }

        [Test]
        public void LeftMenuItemClicked_Position4_OnSettingsClickedCalled()
        {
            _uut.LeftMenuItemClicked(4);
            _fakeView.Received().OnSettingsClicked();
        }

        [Test]
        public void OnStop_HideLeftDrawerCalled()
        {
            _uut.OnStop();
            _fakeView.Received().HideLeftDrawer();
        }


    }
}