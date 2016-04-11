namespace TrafficControl.BLL.CreateUser
{
    public interface ICreateUserModel
    {
        void CreateUser(string email, string password, string confirmPassword, string name, string phoneNumber, string userType);
    }
}