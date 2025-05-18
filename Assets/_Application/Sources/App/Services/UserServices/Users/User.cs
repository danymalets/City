using Newtonsoft.Json;
using Sources.App.Services.UserServices.Users.PreferencesData;
using Sources.App.Services.UserServices.Users.Progresses;
using Sources.App.Services.UserServices.Users.Wallets;

namespace Sources.App.Services.UserServices.Users
{
    public class User
    {
        [JsonProperty] public UserProgress UserProgress { get; } = new ();
        [JsonProperty] public UserWallet UserWallet { get; } = new();
        [JsonProperty] public UserPreferences UserPreferences { get; } = new ();
    }
}