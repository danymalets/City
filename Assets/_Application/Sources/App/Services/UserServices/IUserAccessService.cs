using Sources.App.Services.UserServices.Users;
using Sources.Utils.Di;

namespace Sources.App.Services.UserServices
{
    public interface IUserAccessService : IService
    {
        User User { get; }
    }
}