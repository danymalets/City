using Sources.Services.Di;

namespace Sources.Services.UserService
{
    public interface IUserAccessService : IService
    {
        User User { get; }
    }
}