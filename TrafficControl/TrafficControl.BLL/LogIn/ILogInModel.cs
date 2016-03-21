namespace TrafficControl.BLL.LogIn
{
    public interface ILogInModel
    {
        bool ValidateLogIn(string email, string password);
        string EncryptPassword(string password);
    }
}
