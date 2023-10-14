using Sources.App.Services.UserServices;
using Sources.App.Services.UserServices.Users.Missions;

namespace Sources.App.Data.Missions.Missions
{
    public abstract class FloatQuest<TProgress> : Quest<TProgress>
        where TProgress : SubMissionProgress, new()
    {
        protected override string GetCompletedText() =>
            GetCompletedValue().ToString("0.0");

        protected override string GetRequiredText() =>
            GetRequiredValue().ToString("0.0");
        
        protected abstract float GetCompletedValue();

        protected abstract float GetRequiredValue();
        
        public override bool IsCompleted() =>
            GetCompletedValue() >= GetRequiredValue();

        public override float GetNormalizedProgress() =>
            GetCompletedValue() / GetRequiredValue();
    }
}