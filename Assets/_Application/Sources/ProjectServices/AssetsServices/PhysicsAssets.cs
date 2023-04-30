using UnityEngine;

namespace Sources.ProjectServices.AssetsServices
{
    [CreateAssetMenu(menuName = nameof(Assets) + "/" + nameof(PhysicsAssets), fileName = nameof(PhysicsAssets))]
    public class PhysicsAssets : ScriptableObject
    {
        [field: SerializeField] public PhysicMaterial PlayerPhysicsMaterial { get; private set; }
    }
}