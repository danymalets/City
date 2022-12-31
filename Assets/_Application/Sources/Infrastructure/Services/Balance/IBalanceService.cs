namespace Sources.Infrastructure.Services.Balance
{
    public interface IBalanceService : IService
    {
        LevelBalance GetLevelBalance(int levelNumber);
        int LevelsCount { get; }
    }
}