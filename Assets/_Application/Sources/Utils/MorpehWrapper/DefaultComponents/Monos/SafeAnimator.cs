using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine;

namespace _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Monos
{
    [RequireComponent(typeof(Animator))]
    public class SafeAnimator : MonoBehaviour, IAnimator
    {
        [SerializeField]
        private Animator _animator;

        private void OnValidate()
        {
            _animator = GetComponent<Animator>();
        }

        public void Play(int stateNameHash, int layer, float normalizedTime) =>
            _animator.Play(stateNameHash, layer, normalizedTime);

        public void SetBool(int nameHash, bool value) =>
            _animator.SetBool(nameHash, value);

        public void SetFloat(int nameHash, float value) =>
            _animator.SetFloat(nameHash, value);

        public int GetLayerIndex(string layer) =>
            _animator.GetLayerIndex(layer);
    }
}