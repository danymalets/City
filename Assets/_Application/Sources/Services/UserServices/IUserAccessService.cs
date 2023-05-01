using Sources.Utils.Di;

namespace Sources.Services.UserServices
{
    public interface IUserAccessService : IService
    {
        User User { get; }
    }
}