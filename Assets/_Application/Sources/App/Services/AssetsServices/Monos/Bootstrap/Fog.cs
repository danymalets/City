using Sources.App.Services.AssetsServices.IdleCarSpawns.Common;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Monos.Bootstrap
{
    public class Fog : MonoBehaviour, IFog
    {
        private const float Height = 2.5f;
        
        [SerializeField]
        private MeshRenderer _firstSphere;

        [SerializeField]
        private MeshRenderer _secondSphere;
        
        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public void SetRadius(float radius)
        {
            MaterialPropertyBlock materialPropertyBlock = new();
            
            materialPropertyBlock.SetFloat("_Height", Height / radius / 2);
            _firstSphere.SetPropertyBlock(materialPropertyBlock);
            
            materialPropertyBlock.SetFloat("_Height",Height / (radius + 2.5f) / 2);
            _secondSphere.SetPropertyBlock(materialPropertyBlock);
            
            _firstSphere.transform.localScale = Vector3.one * radius * 2;
            _secondSphere.transform.localScale = Vector3.one * (radius + 2.5f) * 2;
        }
    }
}