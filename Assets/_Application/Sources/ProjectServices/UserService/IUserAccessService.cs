using Sources.Utils.Di;

namespace Sources.ProjectServices.UserService
{
    public interface IUserAccessService : IService
    {
        User User { get; }
    }
}