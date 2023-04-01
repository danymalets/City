using Sources.App.Game.Ecs.DefaultComponents.Views;
using UnityEngine;

namespace Sources.App.Game.Ecs.DefaultComponents.Monos
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

        private void OnValidate()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }
    }
}