using Sources.Game.Missions;

namespace Sources.Infrastructure.Services.User
{
    public class Progress
    {
        public int CurrentLevel { get; set; } = 0;
        public StoryProgress StoryProgress { get; set; } = new();
    }
}