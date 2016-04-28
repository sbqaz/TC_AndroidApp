using System.Threading.Tasks;

namespace TrafficControl.GUI.CreateUser
{
    public interface IChangePasswordPresenter
    {
        Task ChangePassword(string text, string s, string text1);
    }
}