using Sources.Utils.Di;

namespace Sources.App.Services.UserServices
{
    public interface IUserResetService : IService
    {
        void Reset();
    }
}