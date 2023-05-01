using Sources.App.Services.UserServices;
using Sources.Utils.Di;
using TMPro;
using UnityEngine;

namespace Sources.App.UI.Screens.Level
{
    public class CoinsView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _coinsValueText;

        private Currency _coins;
        
        public void Setup()
        {
            _coins = DiContainer.Resolve<IUserAccessService>().User.Wallet.Coins;

            _coinsValueText.text = _coins.Value.ToString();
            _coins.Changed += CoinsValueChanged;
        }

        public void Cleanup()
        {
            _coins.Changed -= CoinsValueChanged;
        }

        private void CoinsValueChanged(long coins)
        {
            _coinsValueText.text = coins.ToString();
        }
    }
}