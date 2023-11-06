using UnityEngine;

namespace Sources.App.Services.BalanceServices.CommonBalances
{
    [CreateAssetMenu(menuName = nameof(Balance) + "/" + nameof(CommonBalance), fileName = nameof(CommonBalance))]
    public class CommonBalance : ScriptableObject
    {
        [field: SerializeField] public float PropsRigidbodyEnableDistance { get; private set; } = 20;
        [field: SerializeField] public float PropsRigidbodyDisableDistance { get; private set; } = 30;
        [field: SerializeField] public float PropsAngleToFallenLayer { get; private set; } = 10;
    }
}