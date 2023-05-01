using Sources.Services.UserServices;

namespace Sources.App.Data.Missions.Missions
{
    public abstract class Quest<TProgress> : SubMission<TProgress>
        where TProgress : SubMissionProgress, new()
    {
        public string GetProgressText() => $"{GetCompletedText()} / {GetRequiredText()}";

        protected abstract string GetCompletedText();
        protected abstract string GetRequiredText();

        public abstract float GetNormalizedProgress();
        public abstract string GetQuestTitle();
        public abstract string GetQuestDescription();
    }
}