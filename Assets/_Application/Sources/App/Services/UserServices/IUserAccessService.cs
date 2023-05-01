using Sources.Utils.Di;

namespace Sources.App.Services.UserServices
{
    public interface IUserAccessService : IService
    {
        User User { get; }
    }
}