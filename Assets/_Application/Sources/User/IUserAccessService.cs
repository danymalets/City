using Sources.Di;

namespace Sources.User
{
    public interface IUserAccessService : IService
    {
        User User { get; }
    }
}