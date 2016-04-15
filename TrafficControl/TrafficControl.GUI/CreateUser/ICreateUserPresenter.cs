using System.Threading.Tasks;

namespace TrafficControl.GUI.CreateUser
{
    public interface ICreateUserPresenter
    {
        Task OnCreateUserClick(string email, string password, string confirmPassword, string firstName, string lastName, string phoneNumber, string typeSelected);
    }
}