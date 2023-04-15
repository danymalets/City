using Sources.ProjectServices.UserService;

namespace _Application.Sources.App.Core.Missions
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