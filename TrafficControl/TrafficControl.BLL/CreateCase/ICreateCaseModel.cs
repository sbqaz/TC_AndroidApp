using System.Collections.Generic;

namespace TrafficControl.BLL.CreateCase
{
    public interface ICreateCaseModel
    {
        List<string> Installations { get; }
        List<string> Informers { get; }
        bool CreateCase(string installation, string informer, string errorDescription);
    }
}