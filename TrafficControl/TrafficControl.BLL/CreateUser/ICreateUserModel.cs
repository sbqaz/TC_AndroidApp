namespace TrafficControl.BLL.CreateUser
{
    public interface ICreateUserModel
    {
        bool CreateUser(string email, string password, string confirmPassword, string firstname, string lastname,
            string phoneNumber, string userType);
    }
}