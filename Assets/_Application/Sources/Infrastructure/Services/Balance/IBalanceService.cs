namespace Sources.Infrastructure.Services.Balance
{
    public interface IBalanceService : IService
    {
        CameraBalance CameraBalance { get; }
    }
}