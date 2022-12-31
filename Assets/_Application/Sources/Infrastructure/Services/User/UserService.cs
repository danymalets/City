using Sources.Game.Characters;
using Sources.Infrastructure.Services.ApplicationCycle;
using UnityEngine;

namespace Sources.Infrastructure.Services.User
{
    public class UserService : IUserService, IInitializable
    {
        private const int UserVersion = 1;
        
        private const string UserVersionKey = "UserVersion";
        private const string UserKey = "UserVersion";
        
        public User User { get; private set; }

        public void Initialize()
        {
            InitializeUser();

            IApplicationCycleService applicationCycle = DiContainer.Resolve<IApplicationCycleService>();
            applicationCycle.PauseStatusChanged += ApplicationCycle_OnPauseStatusChanged;
        }

        private void InitializeUser()
        {
            if (PlayerPrefs.HasKey(UserVersionKey))
            {
                if (UserVersion == PlayerPrefs.GetInt(UserVersionKey))
                {
                    LoadUser();
                }
                else
                {
                    CreateNewUser();
                }
            }
            
            PlayerPrefs.SetInt(UserVersionKey, UserVersion);
        }

        private void CreateNewUser()
        {
            User = new User();
        }

        private void LoadUser()
        {
            string json = PlayerPrefs.GetString(UserKey);
            //
        }

        private void ApplicationCycle_OnPauseStatusChanged(bool paused)
        {
            if (paused)
                Save();
        }
        
        public void Save()
        {
            
        }
    }
}