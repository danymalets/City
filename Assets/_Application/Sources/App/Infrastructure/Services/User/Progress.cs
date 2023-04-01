using Sources.App.Game.Missions;

namespace Sources.App.Infrastructure.Services.User
{
    public class Progress
    {
        public int CurrentLevel { get; set; } = 0;
        public StoryProgress StoryProgress { get; set; } = new();
    }
}