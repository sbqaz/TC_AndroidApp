namespace TrafficControl.GUI.CreateCase
{
    public interface ICreateCaseView
    {
        void ShowMissingInfoError();
        void SetInstallationError();
        void SetInformerError();
        void SetErrorDescriptionError();
        void ShowProgressDialog();
        void HideProgressDialog();
        void CaseCreated();
        void CaseNotCreated();
    }
}