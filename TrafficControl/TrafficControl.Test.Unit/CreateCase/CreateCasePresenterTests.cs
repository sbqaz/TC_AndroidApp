using NSubstitute;
using NUnit.Framework;
using TrafficControl.BLL.CreateCase;
using TrafficControl.GUI.CreateCase;

namespace TrafficControl.Test.Unit.CreateCase
{
    [TestFixture]
    public class CreateCasePresenterTests
    {
        private ICreateCaseView _fakeView;
        private ICreateCaseModel _fakeModel;
        private CreateCasePresenter _uut;

        [SetUp]
        public void Init()
        {
            _fakeView = Substitute.For<ICreateCaseView>();
            _fakeModel = Substitute.For<ICreateCaseModel>();
            _uut = new CreateCasePresenter(_fakeView, _fakeModel);
        }

        [Test]
        public void Ctor_FetchDataCalled()
        {
            _fakeModel.Received().FetchData();
        }

    }
}