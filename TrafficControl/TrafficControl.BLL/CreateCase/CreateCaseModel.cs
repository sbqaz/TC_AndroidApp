using System.Collections.Generic;
using System.Linq;
using Android.Renderscripts;
using TrafficControl.DAL.RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.BLL.CreateCase
{
    class CreateCaseModel : ICreateCaseModel
    {
        private ITCApi _api;

        public Dictionary<string, long> Installations { get; private set; }

        public List<string> Informers { get; private set; }
        public void FetchData()
        {
            Installations = new Dictionary<string, long>();
            var installations = _api.GetInstallations();
            foreach (var i in installations)
            {
                Installations.Add(i.Name, i.Id);
            }

            //To API call?
            string[] informerStrings = { "Politiet", "Borger", "Kommunen" };
            Informers = informerStrings.ToList();
        }

        public bool CreateCase(string installation, string informer, string errorDescription)
        {
            //return _api.CreateCase(??);
            return true;
        }

        public CreateCaseModel(ITCApi api)
        {
            _api = api;
        }
    }
}