namespace TrafficControl.GUI.LogIn
{
    public interface ILogInPresenter
    {
        void OnDestroy();
        void LogInCredentials(string email, string password);
    }
}