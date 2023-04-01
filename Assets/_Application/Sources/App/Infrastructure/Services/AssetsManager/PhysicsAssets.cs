using UnityEngine;

namespace Sources.App.Infrastructure.Services.AssetsManager
{
    [CreateAssetMenu(menuName = nameof(PhysicsAssets) + "/" + nameof(PhysicsAssets), fileName = nameof(PhysicsAssets))]
    public class PhysicsAssets : ScriptableObject
    {
        [field: SerializeField] public PhysicMaterial PlayerPhysicsMaterial { get; private set; }
    }
}