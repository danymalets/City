using Sources.App.Services.UserServices.Users;
using Sources.Services.ApplicationServices;
using Sources.Services.JsonSerializerServices;
using Sources.Services.LogServices;
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
        private readonly IApplicationService _applicationService;
        private readonly ILogService _logService;

        public UserService()
        {
            _jsonSerializer = DiContainer.Resolve<IJsonSerializerService>();
            _playerPrefs = DiContainer.Resolve<IPlayerPrefsService>();
            _logService = DiContainer.Resolve<ILogService>();
            _applicationService = DiContainer.Resolve<IApplicationService>();
        }

        public void Initialize()
        {
            if (!TryInitializeUser())
            {
                return;
            }

            _applicationService.Unfocused += ApplicationCycle_OnUnfocused;
            _applicationService.Paused += ApplicationCycle_OnPaused;
            _applicationService.ApplicationQuit += ApplicationCycle_OnApplicationQuit;
        }

        private bool TryInitializeUser()
        {
            Debug.Log($"z {_playerPrefs.HasKey(UserVersionKey)}");
            
            if (_playerPrefs.TryGetInt(UserVersionKey, out var lastSavedVersion))
            {
                if (TryLoadUser())
                {
                    Debug.Log($"a");

                    if (lastSavedVersion < UserVersion)
                    {
                        // migrations
                    }
                }
                else
                {
                    _logService.LogError("Cannot load user. Quit application.");
                    _applicationService.Quit();
                    return false;
                }
            }
            else
            {
                Debug.Log($"b");

                CreateNewUser();
            }

            return true;
        }

        private bool TryLoadUser()
        {
            var json = _playerPrefs.GetString(UserKey);
            Debug.Log($"Get \n\n {json}");
            if (!_jsonSerializer.TryDeserialize(json, out User user)) return false;
            User = user;
            
            Debug.Log($"Get \n\n {user.UserProgress.IsGreenCarUnlocked}");

            return true;

        }

        private void CreateNewUser() =>
            User = new User();

        private void ApplicationCycle_OnPaused()
        {
            Save();
        }

        private void ApplicationCycle_OnUnfocused()
        {
            Save();
        }

        private void ApplicationCycle_OnApplicationQuit()
        {
            Save();
        }

        public void Save()
        {
#if UNITY_EDITOR
            string jsonDebug = _jsonSerializer.Serialize(User, true);
            _logService.Log($"User save: \n \n{jsonDebug}");
#endif

            _playerPrefs.SetInt(UserVersionKey, UserVersion);

            string json = _jsonSerializer.Serialize(User);
            _playerPrefs.SetString(UserKey, json);
            _playerPrefs.Save();
        }
    }
}