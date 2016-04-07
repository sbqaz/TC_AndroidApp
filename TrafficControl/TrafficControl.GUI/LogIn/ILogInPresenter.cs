using System.Threading.Tasks;

namespace TrafficControl.GUI.LogIn
{
    public interface ILogInPresenter
    {
        void OnDestroy();
        Task LogInCredentialsAsync(string email, string password);
    }
}