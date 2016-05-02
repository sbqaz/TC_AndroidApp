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
            _userTypes = new Dictionary<string, int> {{"Administrator", 2}, {"Montør", 1}, {"Randers Kommune", 0}};
        }

        public bool CreateUser(string email, string password, string confirmPassword, string firstname, string lastname, string phoneNumber, string userType)
        {
            return _api.CreateUser(email, password, confirmPassword, firstname, lastname, _userTypes[userType], phoneNumber);
        }
    }
}