using Sources.ProjectServices.UserService;

namespace Sources.App.Core.Missions
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