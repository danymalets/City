using System;
using Sources.Game.Ecs.DefaultComponents.Views;
using UnityEngine;

namespace Sources.Game.Ecs.DefaultComponents.Monos
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

        private void OnValidate()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }
    }
}