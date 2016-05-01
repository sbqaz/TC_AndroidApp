using System.Collections.Generic;
using System.Linq;
using TrafficControl.DAL.RestSharp;

namespace TrafficControl.BLL.CreateCase
{
    class CreateCaseModel : ICreateCaseModel
    {
        private ITCApi _api;

        public List<string> Installations { get; private set; }
        public List<string> Informers { get; private set; }
        public bool CreateCase(string installation, string informer, string errorDescription)
        {
            //return _api.CreateCase(??);
            return true;
        }

        public CreateCaseModel(ITCApi api)
        {
            _api = api;

            //To API call?
            string[] installationStrings = { "C", "C++", "Java", "C#", "PHP", "JavaScript", "jQuery", "AJAX", "JSON" };
            Installations = installationStrings.ToList();
            
            //To API call?
            string[] informerStrings = { "Politiet", "Borger", "Kommunen" };
            Informers = informerStrings.ToList();
        }
    }
}