using UnityEngine;

namespace Sources.Infrastructure.Services.PlayerPreferences
{
    public class PlayerPrefsService : IPlayerPrefsService
    {
        public bool HasKey(string key) =>
            PlayerPrefs.HasKey(key);

        public string GetString(string key) =>
            PlayerPrefs.GetString(key);

        public void SetString(string key, string value) =>
            PlayerPrefs.SetString(key, value);

        public int GetInt(string key) =>
            PlayerPrefs.GetInt(key);
        
        public void SetInt(string key, int value) => 
            PlayerPrefs.SetInt(key, value);

        public void Save() => 
            PlayerPrefs.Save();
    }
}