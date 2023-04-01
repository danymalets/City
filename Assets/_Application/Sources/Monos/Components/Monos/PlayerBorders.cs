using _Application.Sources.MonoViews.MonoViews;
using Sources.DMorpeh.DefaultComponents.Monos;
using UnityEngine;

namespace _Application.Sources.Monos.Components.Monos
{
    [RequireComponent(typeof(SafeCapsuleCollider))]
    public class PlayerBorders : MonoBehaviour, IPlayerBorders
    {
        [SerializeField]
        private SafeCapsuleCollider _safeCapsuleCollider;

        public SafeCapsuleCollider SafeCapsuleCollider => _safeCapsuleCollider;
        
        private void OnValidate()
        {
            _safeCapsuleCollider = GetComponent<SafeCapsuleCollider>();
        }
    }
}