namespace Sources.Services.UserService
{
    public class MissionProgress
    {
        public int CurrentSubMissionNumber { get; set; } = 0;

        public SubMissionProgress[] SubMissionProgresses { get; set; }
    }
}