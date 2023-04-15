using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine;

namespace Sources.Utils.MorpehWrapper.DefaultComponents.Monos
{
    [RequireComponent(typeof(MeshRenderer))]
    public class SafeMeshRenderer : MonoBehaviour, IMeshRenderer
    {
        [SerializeField]
        private MeshRenderer _meshRenderer;

        public Material Material
        {
            get => _meshRenderer.material;
            set => _meshRenderer.material = value;
        }
        
        public Material SharedMaterial
        {
            get => _meshRenderer.sharedMaterial;
            set => _meshRenderer.sharedMaterial = value;
        }

        public void SetPropertyBlock(MaterialPropertyBlock materialPropertyBlock) => 
            _meshRenderer.SetPropertyBlock(materialPropertyBlock);

        private void OnValidate()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }
    }
}