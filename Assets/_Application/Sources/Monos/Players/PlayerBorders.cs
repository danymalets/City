using Sources.Data.Players;
using Sources.Utils.DMorpeh.DefaultComponents.Monos;
using UnityEngine;

namespace Sources.Monos.Players
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