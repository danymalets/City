using Sources.App.Services.UserServices.Users.Missions;

namespace Sources.App.Services.UserServices.Users.Progresses
{
    public class UserProgress
    {
        public int CurrentLevel { get; set; } = 0;
        public bool IsGreenCarUnlocked { get; set; } = false;
        public bool IsRedCarUnlocked { get; set; } = false;
        public StoryProgress StoryProgress { get; set; } = new();
    }
}