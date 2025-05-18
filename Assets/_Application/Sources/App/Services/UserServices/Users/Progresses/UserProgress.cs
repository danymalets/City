using Newtonsoft.Json;
using Sources.App.Services.UserServices.Users.Missions;

namespace Sources.App.Services.UserServices.Users.Progresses
{
    public class UserProgress
    {
        [JsonProperty] public bool IsRemoveAds { get; set; } = false;
        [JsonProperty] public int CurrentLevel { get; set; } = 0;
        [JsonProperty] public bool IsGreenCarUnlocked { get; set; } = false;
        [JsonProperty] public bool IsRedCarUnlocked { get; set; } = false;
    }
}