namespace TrafficControl.BLL.CreateUser
{
    public interface ICreateUserModel
    {
        bool CreateUser(string email, string password, string name, string phoneNumber, string userType);
    }
}