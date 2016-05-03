using System.Collections.Generic;
using TrafficControl.DAL.RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.BLL.Map
{
    public class MapModel : IMapModel
    {
        private ITCApi _api;

        public IEnumerable<Installation> Installations
        {
            get { return _api.GetInstallations(); }
        }

        public MapModel(ITCApi api)
        {
            _api = api;
        }
    }
}