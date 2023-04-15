using _Application.Sources.Utils.Di;

namespace Sources.ProjectServices.UserService
{
    public interface IUserSaveService : IService
    {
        void Save();
    }
}