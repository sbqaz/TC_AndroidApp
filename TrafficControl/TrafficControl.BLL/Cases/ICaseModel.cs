using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.BLL.Cases
{
    public interface ICaseModel
    {
        Case GetCase(long caseId);
    }
}