using Sources.ProjectServices.UserServices;

namespace Sources.App.Data.Missions.Missions
{
    public abstract class BoolQuest<TProgress> : IntQuest<TProgress>
        where TProgress : SubMissionProgress, new()
    {
        protected override int GetCompletedValue() =>
            WasCompleted() ? 1 : 0;

        protected override int GetRequiredValue() => 1;
        protected abstract bool WasCompleted();
    }
}