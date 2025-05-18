using Sources.Utils.Di;

namespace Sources.Services.PlayerPreferencesServices
{
    public interface IPlayerPrefsService : IService
    {
        bool HasKey(string key);
        
        string GetString(string key);
        void SetString(string key, string value);
        bool TryGetString(string key, out string value);

        int GetInt(string key);
        void SetInt(string key, int value);
        bool TryGetInt(string key, out int value);
        
        void Save();
    }
}