namespace Sources.Infrastructure.Services.PlayerPreferences
{
    public interface IPlayerPrefsService : IService
    {
        bool HasKey(string key);
        
        string GetString(string key);
        void SetString(string key, string value);

        int GetInt(string key);
        void SetInt(string key, int value);
        
        void Save();
    }
}