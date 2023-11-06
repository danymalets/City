using Sources.App.Services.UserServices.Users.PreferencesData;
using Sources.App.Services.UserServices.Users.Progresses;
using Sources.App.Services.UserServices.Users.Wallets;

namespace Sources.App.Services.UserServices.Users
{
    public class User
    {
        public bool IsRemoveAds { get; set; } = false;
        public UserProgress UserProgress { get; private set; } = new ();
        public UserWallet UserWallet { get; } = new();
        public UserPreferences UserPreferences { get; private set; } = new ();
    }
}