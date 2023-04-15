using _Application.Sources.Utils.Di;
using Sources.ProjectServices.UserService;
using TMPro;
using UnityEngine;

namespace _Application.Sources.App.UI.Screens.Level
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