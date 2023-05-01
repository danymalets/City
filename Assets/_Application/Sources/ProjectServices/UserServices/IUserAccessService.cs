using Sources.Utils.Di;

namespace Sources.ProjectServices.UserServices
{
    public interface IUserAccessService : IService
    {
        User User { get; }
    }
}