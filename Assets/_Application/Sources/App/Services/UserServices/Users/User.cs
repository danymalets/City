using Sources.App.Services.UserServices.Users.PreferencesData;
using Sources.App.Services.UserServices.Users.Progresses;
using Sources.App.Services.UserServices.Users.Wallets;

namespace Sources.App.Services.UserServices.Users
{
    public class User
    {
        public bool IsRemoveAds { get; set; } = false;
        public Progress Progress { get; private set; } = new ();
        public Wallet Wallet { get; } = new();
        public Preferences Preferences { get; private set; } = new ();
    }
}