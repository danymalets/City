using System.Linq;
using Sources.Utils.Extensions;
using UnityEngine;

namespace Sources.App.Game.GameObjects.Players.Ragdolls
{
    public class Ragdoll : MonoBehaviour
    {
        [SerializeField]
        private GameObject _glider;

        [SerializeField]
        private Transform _rootBones;

        [SerializeField]
        private Collider _mainCollider;
        
        private Rigidbody[] _bonesRigidbodies;
        private Collider[] _bonesColliders;
        private Rigidbody _rigidbody;

        private TransformData[] _transformData;

        private Animator _animator;

        private void Awake()
        {
            _bonesRigidbodies = _rootBones.GetComponentsInChildren<Rigidbody>();
            _bonesColliders = _rootBones.GetComponentsInChildren<Collider>();
            _animator = GetComponentInChildren<Animator>();
            _rigidbody = GetComponent<Rigidbody>();

            _transformData = GetComponentsInChildren<Transform>()
                .Except(new [] { transform })
                .Select(transform => new TransformData(
                    transform,
                    transform.localPosition,
                    transform.localRotation))
                .ToArray();
        }

        public void Setup()
        {
            foreach (Rigidbody rigidbody in _bonesRigidbodies) 
                rigidbody.isKinematic = true;

            foreach (Collider collider in _bonesColliders)
                collider.enabled = false;
            
            _animator.enabled = true;

            _mainCollider.enabled = true;
            
            _rigidbody.isKinematic = false;
            
            foreach (TransformData transformData in _transformData)
            {
                transformData.Transform.localPosition = transformData.Position;
                transformData.Transform.localRotation = transformData.Rotation;
            }

            _rigidbody.rotation = Quaternion.identity;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }

        public void MakePhysical()
        {
            foreach (Rigidbody rigidbody in _bonesRigidbodies) 
                rigidbody.isKinematic = false;

            foreach (Collider collider in _bonesColliders)
                collider.enabled = true;

            _animator.enabled = false;
            _glider.Disable();

            _mainCollider.enabled = false;
            
            _rigidbody.isKinematic = true;
        }
    }
}