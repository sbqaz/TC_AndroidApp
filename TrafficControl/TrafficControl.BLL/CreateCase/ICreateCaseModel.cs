using System.Collections.Generic;

namespace TrafficControl.BLL.CreateCase
{
    public interface ICreateCaseModel
    {
        Dictionary<string, long> Installations { get; }
        List<string> Informers { get; }
        void FetchData();
        bool CreateCase(string installation, string informer, string errorDescription);
    }
}