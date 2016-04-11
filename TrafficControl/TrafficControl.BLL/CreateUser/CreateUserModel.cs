using System.Threading;
using TrafficControl.DAL.RestSharp;

namespace TrafficControl.BLL.CreateUser
{
    public class CreateUserModel : ICreateUserModel
    {
        private readonly ITCApi _api;

        public CreateUserModel(ITCApi api)
        {
            _api = api;
        }

        public void CreateUser(string email, string password, string confirmPassword, string name, string phoneNumber, string userType)
        {

        }
    }
}