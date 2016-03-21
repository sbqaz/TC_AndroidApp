using TrafficControl.BLL.Home;
using TrafficControl.BLL.LogIn;
using TrafficControl.DAL;

namespace TrafficControl.BLL
{
    public class ModelFactory
    {
        public ModelFactory() { }

        public ILogInModel CreateLogInModel()
        {
            return new LogInModel(new TCApi());
        }

        public IHomeModel CreateHomeModel()
        {
            return new HomeModel();
        }
         
    }
}