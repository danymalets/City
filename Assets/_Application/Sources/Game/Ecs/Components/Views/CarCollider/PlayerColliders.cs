using System.Linq;
using Sources.Game.Constants;
using UnityEditor;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.CarCollider
{
    public class PlayerColliders : MonoBehaviour, IPlayerColliders
    {
        [SerializeField]
        private Collider[] _colliders;

        public Collider[] Colliders => _colliders;

        private void OnValidate()
        {
            if (_colliders != null)
            {
                foreach (Collider collider in _colliders)
                {
                    if (collider != null)
                    {
                        collider.isTrigger = false;
                        collider.gameObject.layer = Layers.Player;
                        
                        collider.material = AssetDatabase.LoadAssetAtPath<PhysicMaterial>(
                            Pathes.PhysicMaterialsPath + nameof(Player) + ".physicMaterial");
                    }
                }
            }
        }
    }
}