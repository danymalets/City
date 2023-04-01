using Sources.Services.Di;

namespace Sources.Services.UserService
{
    public interface IUserSaveService : IService
    {
        void Save();
    }
}