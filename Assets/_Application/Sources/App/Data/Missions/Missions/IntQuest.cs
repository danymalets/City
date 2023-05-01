using Sources.App.Services.UserServices;

namespace Sources.App.Data.Missions.Missions
{
    public abstract class IntQuest<TProgress> : Quest<TProgress>
        where TProgress : SubMissionProgress, new()
    {
        protected sealed override string GetCompletedText() =>
            GetCompletedValue().ToString();

        protected sealed override string GetRequiredText() =>
            GetRequiredValue().ToString();
        
        protected abstract int GetCompletedValue();

        protected abstract int GetRequiredValue();

        public sealed override bool IsCompleted() =>
            GetCompletedValue() >= GetRequiredValue();
        
        public sealed override float GetNormalizedProgress() =>
            (float)GetCompletedValue() / GetRequiredValue();
    }
}