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

        private Entity _entity;

        public EntityCollider[] Colliders => _colliders;

        public void Setup(Entity entity)
        {
            EnableColliders();

            _entity = entity;

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
                if (_entity.NotHas<Collisions>())
                    _entity.Set(new Collisions() { List = new List<CollisionData>() });

                _entity.Get<Collisions>().List
                    .Add(new CollisionData(monoEntity.Entity, collision.impulse.sqrMagnitude));
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