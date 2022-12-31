using Sources.Data;
using Sources.Data.Live;
using TMPro;
using UnityEngine;

namespace Sources.UI.Screens.Level
{
    public class CoinsView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _coinsValueText;

        private LiveInt _coins;
        
        public void Setup()
        {
            _coins = Progress.Coins;

            _coinsValueText.text = _coins.Value.ToString();
            _coins.Changed += OnCoinsValueChanged;
        }

        public void Cleanup()
        {
            _coins.Changed -= OnCoinsValueChanged;
        }

        private void OnCoinsValueChanged(int coins)
        {
            _coinsValueText.text = coins.ToString();
        }
    }
}