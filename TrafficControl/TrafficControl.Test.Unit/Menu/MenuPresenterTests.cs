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
        public void GetMenuItems_FourthItemIsSettings()
        {
            StringAssert.Contains("indstillinger", _uut.GetMenuItems()[3].ToLower());
        }

        [Test]
        public void LeftMenuItemClicked_Position0_OnHomeClickedCalled()
        {
            _uut.LeftMenuItemClicked(0);
            _fakeView.Received().OnHomeClicked();
        }

        [Test]
        public void LeftMenuItemClicked_Position3_OnSettingsClickedCalled()
        {
            _uut.LeftMenuItemClicked(3);
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