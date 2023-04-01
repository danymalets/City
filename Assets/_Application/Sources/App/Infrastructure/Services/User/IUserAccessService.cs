namespace Sources.App.Infrastructure.Services.User
{
    public interface IUserAccessService : IService
    {
        User User { get; }
    }
}