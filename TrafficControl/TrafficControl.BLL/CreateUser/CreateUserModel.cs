using System.Collections.Generic;
using System.Threading;
using TrafficControl.DAL.RestSharp;

namespace TrafficControl.BLL.CreateUser
{
    public class CreateUserModel : ICreateUserModel
    {
        private readonly ITCApi _api;
        private readonly Dictionary<string, int> _userTypes; 

        public CreateUserModel(ITCApi api)
        {
            _api = api;
            _userTypes = new Dictionary<string, int> {{"Administrator", 0}, {"Montør", 1}, {"Randers Kommune", 2}};
        }

        public bool CreateUser(string email, string password, string name, string phoneNumber, string userType)
        {
            return _api.CreateUser(email, password, name, _userTypes[userType], phoneNumber);
        }
    }
}