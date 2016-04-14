using System.Threading.Tasks;

namespace TrafficControl.GUI.CreateUser
{
    public interface ICreateUserPresenter
    {
        Task OnCreateUserClick(string email, string password, string confirmPassword, string name, string phoneNumber, string typeSelected);
    }
}