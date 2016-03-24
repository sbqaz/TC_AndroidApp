using System;
using TrafficControl.BLL.Home;
using TrafficControl.BLL.LogIn;
using TrafficControl.BLL.Settings;
using TrafficControl.DAL;

namespace TrafficControl.BLL
{
    public class ModelFactory
    {
        private static volatile ModelFactory instance;
        private static object syncRoot = new Object();

        private ITCApi _tcApi;
        private ModelFactory(ITCApi tcApi)
        {
            _tcApi = tcApi;
        }

        public static ModelFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ModelFactory(new TCApi());
                    }
                }

                return instance;
            }
        }

        public ILogInModel CreateLogInModel()
        {
            return new LogInModel(_tcApi);
        }

        public IHomeModel CreateHomeModel()
        {
            return new HomeModel();
        }

        public ISettingsModel CreateSettingsModel()
        {
            return new SettingsModel();
        }
         
    }
}