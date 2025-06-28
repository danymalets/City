using Sources.App.Services.UserServices.Users.Missions;

namespace Sources.App.Services.BalanceServices.Missions
{
    public abstract class SubMission<TProgress> : SubMissionBase where TProgress : SubMissionProgress, new()
    {
        public TProgress Progress { get; set; } = new();
    }
}