namespace Sources.Game.Missions
{
    public class MissionProgress
    {
        public int CurrentSubMissionNumber { get; set; } = 0;

        public SubMissionProgress[] SubMissionProgresses { get; set; }
    }
}