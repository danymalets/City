using Sources.ProjectServices.UserService;

namespace _Application.Sources.App.Core.Missions
{
    public abstract class SubMission<TProgress> : SubMissionBase where TProgress : SubMissionProgress, new()
    {
        public TProgress Progress { get; set; } = new();
    }
}