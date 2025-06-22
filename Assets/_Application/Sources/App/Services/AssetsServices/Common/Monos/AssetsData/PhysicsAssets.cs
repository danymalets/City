using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.Monos.AssetsData
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(PhysicsAssets), fileName = nameof(PhysicsAssets))]
    public class PhysicsAssets : ScriptableObject
    {
        [field: SerializeField] public PhysicsMaterial PlayerPhysicsMaterial { get; private set; }
    }
}