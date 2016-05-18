using TrafficControl.DAL.RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.GUI.Cases
{
    public interface ICasePresenter
    {
        Case CurrentCase { get; }
        void SetCurrentCase(long caseId);
        string CaseStatusToString(CaseStatus status);
        string CaseObserverToString(ObserverSelection observer);
        void SetContentView(Case @case);
    }
}