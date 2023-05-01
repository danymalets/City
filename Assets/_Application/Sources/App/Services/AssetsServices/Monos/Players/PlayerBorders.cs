using Sources.App.Data.Players;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Monos.Players
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