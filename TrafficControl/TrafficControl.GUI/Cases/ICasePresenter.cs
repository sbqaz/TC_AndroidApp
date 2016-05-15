using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.GUI.Cases
{
    public interface ICasePresenter
    {
        Case CurrentCase { get; }
        void SetCurrentCase(long caseId);
    }
}