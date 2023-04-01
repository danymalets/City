using Sources.App.Game.Components.Monos;
using Sources.App.Game.Ecs.DefaultComponents.Monos;
using UnityEngine;

namespace Sources.App.Game.Components.Views
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