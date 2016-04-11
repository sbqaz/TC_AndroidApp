namespace TrafficControl.GUI.CreateUser
{
    public interface ICreateUserPresenter
    {
        void OnCreateUserClick(string email, string password, string confirmPassword, string name, string phoneNumber, string typeSelected);
    }
}