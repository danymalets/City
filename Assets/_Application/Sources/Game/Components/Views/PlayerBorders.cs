using Sources.Game.Ecs.DefaultComponents.Monos;
using UnityEngine;

namespace Sources.Game.Components.Views
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