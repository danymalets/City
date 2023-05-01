namespace Sources.Services.UserServices
{
    public class MissionProgress
    {
        public int CurrentSubMissionNumber { get; set; } = 0;

        public SubMissionProgress[] SubMissionProgresses { get; set; }
    }
}