using System.Collections.Generic;
using Scellecs.Morpeh;
using Sirenix.OdinInspector;
using Sources.Game.Constants;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using UnityEngine;
using UnityEditor;

namespace Sources.Game.Ecs.Components.Views.CarCollider
{
    public class PlayerColliders : MonoBehaviour, IPlayerColliders
    {
        [SerializeField]
        private EntityCollider[] _colliders;

        private List<CollisionData> _collisions;

        public EntityCollider[] Colliders => _colliders;

        public void Setup(Entity entity)
        {
            EnableColliders();
            entity.AddList<Collisions, CollisionData>();
            _collisions = entity.GetList<Collisions, CollisionData>();

            foreach (EntityCollider entityCollider in _colliders)
            {
                entityCollider.Setup(entity);
            }
        }

        public void EnableColliders()
        {
            foreach (EntityCollider entityCollider in _colliders)
            {
                entityCollider.Collider.enabled = true;
            }
        }

        public void DisableColliders()
        {
            foreach (EntityCollider entityCollider in _colliders)
            {
                entityCollider.Collider.enabled = false;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            GameObject rootObj = collision.transform.root.gameObject;
            if (rootObj.TryGetComponent(out MonoEntity monoEntity))
            {
                _collisions.Add(new CollisionData(monoEntity.Entity, collision.impulse.sqrMagnitude));
            }
        }

        public void Cleanup()
        {
            foreach (EntityCollider entityCollider in _colliders)
            {
                entityCollider.Cleanup();
            }
        }
        
#if UNITY_EDITOR
        [Button("Bake", ButtonSizes.Large)]
        private void Bake()
        {
            _colliders = GetComponentsInChildren<EntityCollider>();

            if (_colliders != null)
            {
                foreach (EntityCollider entityCollider in _colliders)
                {
                    entityCollider.Collider.isTrigger = false;
                    entityCollider.gameObject.layer = Layers.Player;
                    entityCollider.Collider.material = AssetDatabase.LoadAssetAtPath<PhysicMaterial>(
                        Pathes.PhysicMaterialsPath + "Player" + ".physicMaterial");
                }
            }
        }
#endif
    }
}