namespace TrafficControl.GUI.Cases
{
    public interface ICaseView
    {
        void SetContentViewCreated();
        void SetContentViewStarted();
        void SetContentViewPending();
        void SetContentViewDone();
        void NoCurrentCase();
        void ShowProgressDialog();
        void HideProgressDialog();
        void CaseNotClaimed();
        void CaseClaimed();
        void CaseNotFinished();
        void CaseFinished();
        void CaseNotSetPending();
        void CaseSetPending();
    }
}