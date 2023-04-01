using Sources.Di;

namespace Sources.Services.UserService
{
    public interface IUserAccessService : IService
    {
        User User { get; }
    }
}