using System.Collections.Generic;
using System.Linq;
using Sources.Game.Ecs.MonoEntities;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities;
using UnityEngine;

namespace Sources.Infrastructure.Services.AssetsManager
{
    [CreateAssetMenu(menuName = nameof(PhysicsAssets) + "/" + nameof(PhysicsAssets), fileName = nameof(PhysicsAssets))]
    public class PhysicsAssets : ScriptableObject
    {
        [field: SerializeField] public PhysicMaterial PlayerPhysicsMaterial { get; private set; }
    }
}