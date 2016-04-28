namespace TrafficControl.BLL.CreateUser
{
    public interface IChangePasswordModel
    {
        bool ChangePassword(string oldPw, string newPw);
    }
}