using System.Collections.Generic;
using System.Linq;
using TrafficControl.DAL.RestSharp;

namespace TrafficControl.BLL.CreateCase
{
    public class CreateCaseModel : ICreateCaseModel
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
            string[] informerStrings = { "Politiet", "Kommunen", "Borger", "Montør" };
            Informers = informerStrings.ToList();
        }

        public bool CreateCase(string installation, string informer, string errorDescription)
        {
            //return _api.CreateCase(??);
            ObserverSelection informerSelection = ObserverSelection.Undefined;
            if (informer == Informers[0])
            {
                informerSelection = ObserverSelection.Police;
            }
            else if (informer == Informers[1])
            {
                informerSelection = ObserverSelection.User;
            }
            else if (informer == Informers[2])
            {
                informerSelection = ObserverSelection.ThirdPart;
            }
            else if (informer == Informers[3])
            {
                informerSelection = ObserverSelection.Own;
            }

            return _api.CreateCase(Installations[installation], informerSelection, errorDescription);
        }

        public CreateCaseModel(ITCApi api)
        {
            _api = api;
        }
    }
}