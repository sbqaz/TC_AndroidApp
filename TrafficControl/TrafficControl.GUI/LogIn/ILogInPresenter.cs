namespace TrafficControl.GUI.LogIn
{
    public interface ILogInPresenter
    {
        void OnDestroy();
        void LogInCredentialsAsync(string email, string password);
    }
}