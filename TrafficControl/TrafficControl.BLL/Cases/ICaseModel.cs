using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.BLL.Cases
{
    public interface ICaseModel
    {
        Case GetCase(long caseId);
        bool ClaimCase(long id);
        bool UpdateCase(Case @case);
    }
}