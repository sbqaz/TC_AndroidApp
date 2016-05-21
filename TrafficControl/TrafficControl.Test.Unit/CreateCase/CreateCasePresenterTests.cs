using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using TrafficControl.BLL.CreateCase;
using TrafficControl.DAL.RestSharp.Types;
using TrafficControl.GUI.CreateCase;

namespace TrafficControl.Test.Unit.CreateCase
{
    [TestFixture]
    public class CreateCasePresenterTests
    {
        private ICreateCaseView _fakeView;
        private ICreateCaseModel _fakeModel;
        private CreateCasePresenter _uut;
        private List<Installation> _installations;

        [SetUp]
        public void Init()
        {
            _fakeView = Substitute.For<ICreateCaseView>();
            _fakeModel = Substitute.For<ICreateCaseModel>();

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

            _fakeModel.Installations.Returns(_installations.ToDictionary(i => i.Name, i => i.Id));

            _uut = new CreateCasePresenter(_fakeView, _fakeModel);
        }

        [Test]
        public void Ctor_FetchDataCalled()
        {
            _fakeModel.Received().FetchData();
        }

        [Test]
        public void GetInformers_ConsistentWithModel()
        {
            List<string> informers = new List<string> {"One", "Two", "Three"};
            _fakeModel.Informers.Returns(informers);

            Assert.That(_uut.GetInformers(), Is.EqualTo(informers));
        }

        [Test]
        public void GetInstallations_FirstValue_ConsistentWithKeysInModel()
        {
            StringAssert.Contains("First", _uut.GetInstallations()[0]);
        }

        [Test]
        public void GetInstallations_SecondValue_ConsistentWithKeysInModel()
        {
            StringAssert.Contains("Second", _uut.GetInstallations()[1]);
        }

        [Test]
        public void GetInstallations_ThirdValue_ConsistentWithKeysInModel()
        {
            StringAssert.Contains("Third", _uut.GetInstallations()[2]);
        }

        [Test]
        public void CreateCase_InstallationNull_ShowMissingInfoErrorCalled()
        {
            _uut.CreateCase(null, "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void CreateCase_InstallationNull_SetInstallationErrorCalled()
        {
            _uut.CreateCase(null, "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().SetInstallationError();
        }

        [Test]
        public void CreateCase_InstallationEmpty_ShowMissingInfoErrorCalled()
        {
            _uut.CreateCase("", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void CreateCase_InstallationEmpty_SetInstallationErrorCalled()
        {
            _uut.CreateCase("", "NotEmpty", "NotEmpty").Wait();
            _fakeView.Received().SetInstallationError();
        }

        [Test]
        public void CreateCase_InformerNull_ShowMissingInfoErrorCalled()
        {
            _uut.CreateCase("NotEmpty", null, "NotEmpty").Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void CreateCase_InformerNull_SetInformerErrorCalled()
        {
            _uut.CreateCase("NotEmpty", null, "NotEmpty").Wait();
            _fakeView.Received().SetInformerError();
        }

        [Test]
        public void CreateCase_InformerEmpty_ShowMissingInfoErrorCalled()
        {
            _uut.CreateCase("NotEmpty", "", "NotEmpty").Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void CreateCase_InformerEmpty_SetInformerErrorCalled()
        {
            _uut.CreateCase("NotEmpty", "", "NotEmpty").Wait();
            _fakeView.Received().SetInformerError();
        }

        [Test]
        public void CreateCase_ErrorDescriptionNull_ShowMissingInfoErrorCalled()
        {
            _uut.CreateCase("NotEmpty", "NotEmpty", null).Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void CreateCase_ErrorDescriptionNull_SetErrorDescriptionErrorCalled()
        {
            _uut.CreateCase("NotEmpty", "NotEmpty", null).Wait();
            _fakeView.Received().SetErrorDescriptionError();
        }

        [Test]
        public void CreateCase_ErrorDescriptionEmpty_ShowMissingInfoErrorCalled()
        {
            _uut.CreateCase("NotEmpty", "NotEmpty", "").Wait();
            _fakeView.Received().ShowMissingInfoError();
        }

        [Test]
        public void CreateCase_ErrorDescriptionEmpty_SetErrorDescriptionErrorCalled()
        {
            _uut.CreateCase("NotEmpty", "NotEmpty", "").Wait();
            _fakeView.Received().SetErrorDescriptionError();
        }

        [Test]
        public void CreateCase_ValidInfo_ShowProgressDialogCalled()
        {
            _uut.CreateCase("Valid", "Valid", "Valid").Wait();
            _fakeView.Received().ShowProgressDialog();
        }

        [Test]
        public void CreateCase_ValidInfo_HideProgressDialogCalled()
        {
            _fakeModel.CreateCase("Valid", "Valid", "Valid").Returns(true);
            _uut.CreateCase("Valid", "Valid", "Valid").Wait();
            _fakeView.Received().HideProgressDialog();
        }

        [Test]
        public void CreateCase_ValidInfo_CaseCreatedCalled()
        {
            _fakeModel.CreateCase("Valid", "Valid", "Valid").Returns(true);
            _uut.CreateCase("Valid", "Valid", "Valid").Wait();
            _fakeView.Received().CaseCreated();
        }

        [Test]
        public void CreateCase_InvalidInfo_HideProgressDialogCalled()
        {
            _fakeModel.CreateCase("Valid", "Valid", "Valid").Returns(true);
            _uut.CreateCase("Invalid", "Invalid", "Invalid").Wait();
            _fakeView.Received().HideProgressDialog();
        }

        [Test]
        public void CreateCase_InvalidInfo_CaseNotCreatedCalled()
        {
            _fakeModel.CreateCase("Valid", "Valid", "Valid").Returns(true);
            _uut.CreateCase("Invalid", "Invalid", "Invalid").Wait();
            _fakeView.Received().CaseNotCreated();
        }
    }
}