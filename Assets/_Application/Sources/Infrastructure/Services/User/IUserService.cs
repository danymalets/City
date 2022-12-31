namespace Sources.Infrastructure.Services.User
{
    public interface IUserService : IService
    {
        User User { get; }

        void Save();
    }
}