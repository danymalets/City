using UnityEngine;

namespace Sources.App.Services.AssetsServices.Monos.AssetsData
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(PhysicsAssets), fileName = nameof(PhysicsAssets))]
    public class PhysicsAssets : ScriptableObject
    {
        [field: SerializeField] public PhysicMaterial PlayerPhysicsMaterial { get; private set; }
    }
}