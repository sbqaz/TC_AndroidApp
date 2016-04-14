using System;
using TrafficControl.BLL.CreateUser;
using TrafficControl.BLL.Home;
using TrafficControl.BLL.LogIn;
using TrafficControl.BLL.Settings;
using TrafficControl.DAL.RestSharp;

namespace TrafficControl.BLL
{
    public class ModelFactory
    {
        private static volatile ModelFactory _instance;
        private static readonly object SyncRoot = new Object();

        private readonly ITCApi _tcApi;
        private readonly ILogInModel _logInModel;
        private readonly IHomeModel _homeModel;
        private readonly ISettingsModel _settingsModel;
        private ICreateUserModel _createUserModel;

        private ModelFactory()
        {
            _tcApi = new TCApi();
            _logInModel = new LogInModel(_tcApi);
            _homeModel = new HomeModel();
            _settingsModel = new SettingsModel();
            _createUserModel = new CreateUserModel(_tcApi);
        }

        public static ModelFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new ModelFactory();
                    }
                }

                return _instance;
            }
        }

        public ILogInModel CreateLogInModel()
        {
            return _logInModel;
        }

        public IHomeModel CreateHomeModel()
        {
            return _homeModel;
        }

        public ISettingsModel CreateSettingsModel()
        {
            return _settingsModel;
        }

        public ICreateUserModel CreateCreateUserModel()
        {
            return _createUserModel;
        }
    }
}