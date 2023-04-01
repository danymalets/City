using Sources.App.Game.GameObjects.Players;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Game.UI.Screens.Level
{
    public class PlayerLevelProgressView : MonoBehaviour
    {
        private Slider _slider;

        private PlayerLevelProgress _playerLevelProgress;

        [SerializeField]
        private Image _playerImage;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }
        
        public void Setup(PlayerLevelProgress playerLevelProgress, Color color = default)
        {
            _playerLevelProgress = playerLevelProgress;
            _slider.value = 0;
            
            if (_playerImage != null) 
                _playerImage.color = color;

            _playerLevelProgress.ProgressChanged += OnPlayerLevelProgressChanged;
        }

        public void Cleanup()
        {
            _playerLevelProgress.ProgressChanged -= OnPlayerLevelProgressChanged;
        }

        private void OnPlayerLevelProgressChanged(float value)
        {
            _slider.value = value;
        }
    }
}