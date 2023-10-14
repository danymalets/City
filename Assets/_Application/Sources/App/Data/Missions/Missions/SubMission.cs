using Sources.App.Services.UserServices;
using Sources.App.Services.UserServices.Users.Missions;

namespace Sources.App.Data.Missions.Missions
{
    public abstract class SubMission<TProgress> : SubMissionBase where TProgress : SubMissionProgress, new()
    {
        public TProgress Progress { get; set; } = new();
    }
}