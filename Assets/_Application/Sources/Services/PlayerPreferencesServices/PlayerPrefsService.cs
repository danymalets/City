using UnityEngine;

namespace Sources.Services.PlayerPreferencesServices
{
    public class PlayerPrefsService : IPlayerPrefsService
    {
        public bool HasKey(string key) =>
            PlayerPrefs.HasKey(key);

        public string GetString(string key) =>
            PlayerPrefs.GetString(key);

        public void SetString(string key, string value) =>
            PlayerPrefs.SetString(key, value);

        public bool TryGetString(string key, out string value)
        {
            if (HasKey(key))
            {
                value = PlayerPrefs.GetString(key);
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }

        public int GetInt(string key) =>
            PlayerPrefs.GetInt(key);
        
        public void SetInt(string key, int value) => 
            PlayerPrefs.SetInt(key, value);

        public bool TryGetInt(string key, out int value)
        {
            if (HasKey(key))
            {
                value = PlayerPrefs.GetInt(key);
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }

        public void Save() => 
            PlayerPrefs.Save();

        public void ClearPlayerPrefs() => 
            PlayerPrefs.DeleteAll();
    }
}