using Sources.Services.UserService;

namespace Sources.App.Game.Missions
{
    public abstract class SubMission<TProgress> : SubMissionBase where TProgress : SubMissionProgress, new()
    {
        public TProgress Progress { get; set; } = new();
    }
}