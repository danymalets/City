using System;
using Sources.App.Services.UserServices.Users;
using Sources.Services.ApplicationServices;
using Sources.Services.JsonSerializerServices;
using Sources.Services.LogServices;
using Sources.Services.PlayerPreferencesServices;
using Sources.Utils.Di;
using UnityEngine;
using ILogger = Sources.Services.LogServices.ILogger;

namespace Sources.App.Services.UserServices
{
    public class UserService : IUserAccessService, IUserSaveService, IUserResetService, IInitializable
    {
        private const int UserVersion = 1;

        private const string UserVersionKey = "UserVersion";
        private const string UserKey = "User";

        public User User { get; private set; }

        public Action UserChanged { get; }

        private readonly IJsonSerializerService _jsonSerializer;
        private readonly IPlayerPrefsService _playerPrefs;
        private readonly IApplicationService _applicationService;
        private readonly ILogger _logger;

        public UserService()
        {
            _jsonSerializer = DiContainer.Resolve<IJsonSerializerService>();
            _playerPrefs = DiContainer.Resolve<IPlayerPrefsService>();
            _logger = DiContainer.Resolve<ILogService>().CreateLogger<UserService>();
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
            if (_playerPrefs.TryGetInt(UserVersionKey, out var lastSavedVersion))
            {
                if (TryLoadUser())
                {
                    if (lastSavedVersion < UserVersion)
                    {
                        // migrations
                        
                    }
                }
                else
                {
                    _logger.LogError($"Cannot load user v{lastSavedVersion}->v{UserVersion}. Quit application.");
                    _applicationService.Quit();
                    return false;
                }
            }
            else
            {
                CreateNewUser();
            }

            return true;
        }

        private bool TryLoadUser()
        {
            var json = _playerPrefs.GetString(UserKey);
            
            if (!_jsonSerializer.TryDeserialize(json, out User user))
            {
                return false;
            }
            
            User = user;
            return true;

        }
        
        public void Reset()
        {
            CreateNewUser();
            Save();
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
            _logger.Log($"User save: \n \n{jsonDebug}");
#endif

            _playerPrefs.SetInt(UserVersionKey, UserVersion);

            string json = _jsonSerializer.Serialize(User);
            _playerPrefs.SetString(UserKey, json);
            _playerPrefs.Save();
        }
    }
}