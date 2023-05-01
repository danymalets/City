using Sources.Services.ApplicationServices;
using Sources.Services.JsonSerializerServices;
using Sources.Services.PlayerPreferencesServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Services.UserServices
{
    public class UserService : IUserAccessService, IUserSaveService, IInitializable
    {
        private const int UserVersion = 1;

        private const string UserVersionKey = "UserVersion";
        private const string UserKey = "User";

        public User User { get; private set; }

        private readonly IJsonSerializerService _jsonSerializer;
        private readonly IPlayerPrefsService _playerPrefs;

        public UserService()
        {
            _jsonSerializer = DiContainer.Resolve<IJsonSerializerService>();
            _playerPrefs = DiContainer.Resolve<IPlayerPrefsService>();
        }

        public void Initialize()
        {
            InitializeUser();

            IApplicationService application = DiContainer.Resolve<IApplicationService>();
            application.PauseStatusChanged += ApplicationCycle_OnPauseStatusChanged;
            application.ApplicationQuit += ApplicationCycle_OnApplicationQuit;
        }

        private void InitializeUser()
        {
            if (_playerPrefs.HasKey(UserVersionKey))
            {
                if (UserVersion == _playerPrefs.GetInt(UserVersionKey))
                {
                    TryLoadUser();
                }
                else
                {
                    CreateNewUser();
                }
            }
            else
            {
                CreateNewUser();
            }
        }

        private void TryLoadUser()
        {
            string json = _playerPrefs.GetString(UserKey);

            if (_jsonSerializer.TryDeserialize(json, out User user))
            {
                User = user;
            }
            else
            {
                CreateNewUser();
            }
        }

        private void CreateNewUser() =>
            User = new User();

        private void ApplicationCycle_OnPauseStatusChanged(bool paused)
        {
            if (paused)
                Save();
        }

        private void ApplicationCycle_OnApplicationQuit()
        {
            Save();
        }

        public void Save()
        {
            _playerPrefs.SetInt(UserVersionKey, UserVersion);

#if UNITY_EDITOR
            string jsonDebug = _jsonSerializer.Serialize(User, true);
            Debug.Log($"User save: \n \n{jsonDebug}");
#endif

            string json = _jsonSerializer.Serialize(User);
            _playerPrefs.SetString(UserKey, json);
            _playerPrefs.Save();
        }
    }
}