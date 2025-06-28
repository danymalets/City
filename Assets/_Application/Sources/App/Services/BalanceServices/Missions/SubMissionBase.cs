namespace Sources.App.Services.BalanceServices.Missions
{
    public abstract class SubMissionBase
    {
        public abstract void Start();

        public abstract bool IsCompleted();
    }
}