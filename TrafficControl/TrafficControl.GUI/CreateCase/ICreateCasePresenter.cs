using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrafficControl.GUI.CreateCase
{
    public interface ICreateCasePresenter
    {
        List<string> GetInformers();
        List<string> GetInstallations();
        Task CreateCase(string installation, string informer, string errorDescription);
    }
}