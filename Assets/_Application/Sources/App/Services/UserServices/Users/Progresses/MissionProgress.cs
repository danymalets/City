using Sources.App.Services.UserServices.Users.Missions;

namespace Sources.App.Services.UserServices.Users.Progresses
{
    public class MissionProgress
    {
        public int CurrentSubMissionNumber { get; set; } = 0;

        public SubMissionProgress[] SubMissionProgresses { get; set; }
    }
}