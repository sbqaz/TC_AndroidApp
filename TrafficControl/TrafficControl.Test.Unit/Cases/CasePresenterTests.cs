using NSubstitute;
using NUnit.Framework;
using TrafficControl.BLL.Cases;
using TrafficControl.DAL.RestSharp;
using TrafficControl.DAL.RestSharp.Types;
using TrafficControl.GUI.Cases;

namespace TrafficControl.Test.Unit.Cases
{
    [TestFixture]
    public class CasePresenterTests
    {
        private ICaseView _fakeView;
        private ICaseModel _fakeModel;
        private CasePresenter _uut;

        [SetUp]
        public void Init()
        {
            _fakeView = Substitute.For<ICaseView>();
            _fakeModel = Substitute.For<ICaseModel>();
            _uut = new CasePresenter(_fakeView, _fakeModel);
        }

        [Test]
        public void SetCurrentCase_ValidId_CurrentCaseIsSetToCaseFromModel()
        {
            var testCase = new Case
            {
                Id = 1
            };
            _fakeModel.GetCase(1).Returns(testCase);
            _uut.SetCurrentCase(1);
            Assert.That(_uut.CurrentCase, Is.EqualTo(testCase));
        }

        [Test]
        public void CaseStatusToString_CalledWithCreated_ReturnCorrectString()
        {
            StringAssert.Contains("oprettet", _uut.CaseStatusToString(CaseStatus.Created).ToLower());
        }

        [Test]
        public void CaseStatusToString_CalledWithDone_ReturnCorrectString()
        {
            StringAssert.Contains("udført", _uut.CaseStatusToString(CaseStatus.Done).ToLower());
        }

        [Test]
        public void CaseStatusToString_CalledWithPending_ReturnCorrectString()
        {
            StringAssert.Contains("afventer", _uut.CaseStatusToString(CaseStatus.Pending).ToLower());
        }

        [Test]
        public void CaseStatusToString_CalledWithStarted_ReturnCorrectString()
        {
            StringAssert.Contains("begyndt", _uut.CaseStatusToString(CaseStatus.Started).ToLower());
        }

        [Test]
        public void CaseObserverToString_CalledWithPolice_ReturnCorrectString()
        {
            StringAssert.Contains("politiet", _uut.CaseObserverToString(ObserverSelection.Police).ToLower());
        }

        [Test]
        public void CaseObserverToString_CalledWithUser_ReturnCorrectString()
        {
            StringAssert.Contains("kommunen", _uut.CaseObserverToString(ObserverSelection.User).ToLower());
        }

        [Test]
        public void CaseObserverToString_CalledWithOwn_ReturnCorrectString()
        {
            StringAssert.Contains("montør", _uut.CaseObserverToString(ObserverSelection.Own).ToLower());
        }

        [Test]
        public void CaseObserverToString_CalledWithThirdPart_ReturnCorrectString()
        {
            StringAssert.Contains("borger", _uut.CaseObserverToString(ObserverSelection.ThirdPart).ToLower());
        }

        [Test]
        public void CaseObserverToString_CalledWithUndefined_ReturnCorrectString()
        {
            StringAssert.Contains("ikke defineret", _uut.CaseObserverToString(ObserverSelection.Undefined).ToLower());
        }

        [Test]
        public void SetContentView_CaseIsNull_NoCallsOnView()
        {
            _uut.SetContentView(null);
            _fakeView.DidNotReceive();
        }

        [Test]
        public void SetContentView_CaseStatusCreated_CorrentContentViewCalled()
        {
            _uut.SetContentView(new Case {Status = CaseStatus.Created});
            _fakeView.Received().SetContentViewCreated();
        }

        [Test]
        public void SetContentView_CaseStatusStarted_CorrentContentViewCalled()
        {
            _uut.SetContentView(new Case { Status = CaseStatus.Started });
            _fakeView.Received().SetContentViewStarted();
        }

        [Test]
        public void SetContentView_CaseStatusPending_CorrentContentViewCalled()
        {
            _uut.SetContentView(new Case { Status = CaseStatus.Pending });
            _fakeView.Received().SetContentViewPending();
        }

        [Test]
        public void SetContentView_CaseStatusDone_CorrentContentViewCalled()
        {
            _uut.SetContentView(new Case { Status = CaseStatus.Done });
            _fakeView.Received().SetContentViewDone();
        }

        [Test]
        public void ClaimCase_CurrentCaseIsNull_NoCurrentCaseCalled()
        {
            _uut.ClaimCase().Wait();
            _fakeView.Received().NoCurrentCase();
        }

        [Test]
        public void ClaimCase_CurrentCaseIsNotNull_ShowProgressDialogCalled()
        {
            var testCase = new Case
            {
                Id = 1
            };
            _fakeModel.GetCase(1).Returns(testCase);
            _uut.SetCurrentCase(1);

            _uut.ClaimCase().Wait();

            _fakeView.Received().ShowProgressDialog();
        }

        [Test]
        public void ClaimCase_CurrentCaseIsNotNullAndModelReturnsTrue_HideProgressDialogCalled()
        {
            var testCase = new Case
            {
                Id = 1
            };
            _fakeModel.GetCase(1).Returns(testCase);
            _uut.SetCurrentCase(1);
            _fakeModel.ClaimCase(1).Returns(true);

            _uut.ClaimCase().Wait();

            _fakeView.Received().HideProgressDialog();
        }

        [Test]
        public void ClaimCase_CurrentCaseIsNotNullAndModelReturnsTrue_CaseClaimedCalled()
        {
            var testCase = new Case
            {
                Id = 1
            };
            _fakeModel.GetCase(1).Returns(testCase);
            _uut.SetCurrentCase(1);
            _fakeModel.ClaimCase(1).Returns(true);

            _uut.ClaimCase().Wait();

            _fakeView.Received().CaseClaimed();
        }

        [Test]
        public void ClaimCase_CurrentCaseIsNotNullAndModelReturnsFalse_HideProgressDialogCalled()
        {
            var testCase = new Case
            {
                Id = 1
            };
            _fakeModel.GetCase(1).Returns(testCase);
            _uut.SetCurrentCase(1);
            _fakeModel.ClaimCase(1).Returns(false);

            _uut.ClaimCase().Wait();

            _fakeView.Received().HideProgressDialog();
        }

        [Test]
        public void ClaimCase_CurrentCaseIsNotNullAndModelReturnsFalse_CaseNotClaimedCalled()
        {
            var testCase = new Case
            {
                Id = 1
            };
            _fakeModel.GetCase(1).Returns(testCase);
            _uut.SetCurrentCase(1);
            _fakeModel.ClaimCase(1).Returns(false);

            _uut.ClaimCase().Wait();

            _fakeView.Received().CaseNotClaimed();
        }

        [Test]
        public void FinishCase_RepairMade_CurrentCaseRepairMadeSetCorrectly()
        {
            var testCase = new Case
            {
                Id = 1
            };
            _fakeModel.GetCase(1).Returns(testCase);
            _uut.SetCurrentCase(1);

            _uut.FinishCase("RepairMade", "");

            Assert.That(_uut.CurrentCase.MadeRepair, Is.EqualTo("RepairMade"));
        }

        [Test]
        public void FinishCase_UserComment_CurrentCaseUserCommentSetCorrectly()
        {
            var testCase = new Case
            {
                Id = 1
            };
            _fakeModel.GetCase(1).Returns(testCase);
            _uut.SetCurrentCase(1);

            _uut.FinishCase("", "UserComment");

            Assert.That(_uut.CurrentCase.UserComment, Is.EqualTo("UserComment"));
        }

        [Test]
        public void FinishCase_CaseStatus_CurrentCaseStatusIsDone()
        {
            var testCase = new Case
            {
                Id = 1
            };
            _fakeModel.GetCase(1).Returns(testCase);
            _uut.SetCurrentCase(1);

            _uut.FinishCase("", "");

            Assert.That(_uut.CurrentCase.Status, Is.EqualTo(CaseStatus.Done));
        }

        [Test]
        public void FinishCase_ModelUpdateCaseReturnsTrue_CaseFinishedCalled()
        {
            var testCase = new Case
            {
                Id = 1,
                Status = CaseStatus.Done
            };
            _fakeModel.GetCase(1).Returns(testCase);
            _uut.SetCurrentCase(1);
            _fakeModel.UpdateCase(testCase).Returns(true);

            _uut.FinishCase("", "");

            _fakeView.Received().CaseFinished();
        }

        [Test]
        public void FinishCase_ModelUpdateCaseReturnsFalse_CaseNotFinishedCalled()
        {
            var testCase = new Case
            {
                Id = 1,
                Status = CaseStatus.Done
            };
            _fakeModel.GetCase(1).Returns(testCase);
            _uut.SetCurrentCase(1);
            _fakeModel.UpdateCase(testCase).Returns(false);

            _uut.FinishCase("", "");

            _fakeView.Received().CaseNotFinished();
        }

        [Test]
        public void PendingCase_RepairMade_CurrentCaseRepairMadeSetCorrectly()
        {
            var testCase = new Case
            {
                Id = 1
            };
            _fakeModel.GetCase(1).Returns(testCase);
            _uut.SetCurrentCase(1);

            _uut.PendingCase("RepairMade", "");

            Assert.That(_uut.CurrentCase.MadeRepair, Is.EqualTo("RepairMade"));
        }

        [Test]
        public void PendingCase_UserComment_CurrentCaseUserCommentSetCorrectly()
        {
            var testCase = new Case
            {
                Id = 1
            };
            _fakeModel.GetCase(1).Returns(testCase);
            _uut.SetCurrentCase(1);

            _uut.PendingCase("", "UserComment");

            Assert.That(_uut.CurrentCase.UserComment, Is.EqualTo("UserComment"));
        }

        [Test]
        public void PendingCase_CaseStatus_CurrentCaseStatusIsPending()
        {
            var testCase = new Case
            {
                Id = 1
            };
            _fakeModel.GetCase(1).Returns(testCase);
            _uut.SetCurrentCase(1);

            _uut.PendingCase("", "");

            Assert.That(_uut.CurrentCase.Status, Is.EqualTo(CaseStatus.Pending));
        }

        [Test]
        public void PendingCase_CaseWorker_CurrentCaseWorkerSetEmpty()
        {
            var testCase = new Case
            {
                Id = 1,
                Worker = "NotAnEmptyString"
            };
            _fakeModel.GetCase(1).Returns(testCase);
            _uut.SetCurrentCase(1);

            _uut.PendingCase("", "");

            Assert.That(_uut.CurrentCase.Worker, Is.EqualTo(""));
        }

        [Test]
        public void PendingCase_ModelUpdateCaseReturnsTrue_CaseSetPendingCalled()
        {
            var testCase = new Case
            {
                Id = 1,
                Status = CaseStatus.Pending
            };
            _fakeModel.GetCase(1).Returns(testCase);
            _uut.SetCurrentCase(1);
            _fakeModel.UpdateCase(testCase).Returns(true);

            _uut.PendingCase("", "");

            _fakeView.Received().CaseSetPending();
        }

        [Test]
        public void PendingCase_ModelUpdateCaseReturnsFalse_CaseNotSetPendingCalled()
        {
            var testCase = new Case
            {
                Id = 1,
                Status = CaseStatus.Pending
            };
            _fakeModel.GetCase(1).Returns(testCase);
            _uut.SetCurrentCase(1);
            _fakeModel.UpdateCase(testCase).Returns(false);

            _uut.PendingCase("", "");

            _fakeView.Received().CaseNotSetPending();
        }

        [Test]
        public void SaveUserComment_UserComment_CurrentCaseUserCommentSetCorrectly()
        {
            var testCase = new Case
            {
                Id = 1
            };
            _fakeModel.GetCase(1).Returns(testCase);
            _uut.SetCurrentCase(1);

            _uut.SaveUserComment("UserComment");

            Assert.That(_uut.CurrentCase.UserComment, Is.EqualTo("UserComment"));
        }

        [Test]
        public void SaveUserComment_ModelUpdateCaseReturnsTrue_CaseSavedCalled()
        {
            var testCase = new Case
            {
                Id = 1,
            };
            _fakeModel.GetCase(1).Returns(testCase);
            _uut.SetCurrentCase(1);
            _fakeModel.UpdateCase(testCase).Returns(true);

            _uut.SaveUserComment("");

            _fakeView.Received().CaseSaved();
        }

        [Test]
        public void SaveUserComment_ModelUpdateCaseReturnsFalse_CaseNotSavedCalled()
        {
            var testCase = new Case
            {
                Id = 1,
            };
            _fakeModel.GetCase(1).Returns(testCase);
            _uut.SetCurrentCase(1);
            _fakeModel.UpdateCase(testCase).Returns(false);

            _uut.SaveUserComment("");

            _fakeView.Received().CaseNotSaved();
        }
    }
}