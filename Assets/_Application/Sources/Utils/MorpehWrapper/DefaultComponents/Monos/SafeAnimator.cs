using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine;

namespace Sources.Utils.MorpehWrapper.DefaultComponents.Monos
{
    [RequireComponent(typeof(Animator))]
    public class SafeAnimator : SafeComponent<Animator>, IAnimator
    {
        public void Play(int stateNameHash, int layer, float normalizedTime) =>
            Unsafe.Play(stateNameHash, layer, normalizedTime);

        public void SetBool(int nameHash, bool value) =>
            Unsafe.SetBool(nameHash, value);

        public void SetFloat(int nameHash, float value) =>
            Unsafe.SetFloat(nameHash, value);

        public int GetLayerIndex(string layer) =>
            Unsafe.GetLayerIndex(layer);

        public void Rebind() => 
            Unsafe.Rebind();

        public bool KeepAnimatorControllerStateOnDisable
        {
            get => Unsafe.keepAnimatorStateOnDisable;
            set => Unsafe.keepAnimatorStateOnDisable = value;
        }
    }
}