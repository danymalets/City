using System;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.CarColors
{
    public class CarMesh : MonoBehaviour, ICarMesh
    {
        [SerializeField]
        private MeshRenderer[] _meshRenderers;

        private void Awake()
        {
            foreach (MeshRenderer meshRenderer in _meshRenderers)
            {
                meshRenderer.material = new Material(meshRenderer.material);
            }
        }

        private void OnValidate()
        {
            _meshRenderers = new[] {GetComponentInChildren<MeshRenderer>()};
        }

        public void SetupColor(CarColorType carColorType)
        {
            DAssert.IsTrue(carColorType != CarColorType.None);
            foreach (MeshRenderer meshRenderer in _meshRenderers)
            {
                meshRenderer.material.SetInt("_TargetIndex", (int)carColorType);
            }
        }

        public MeshRenderer[] MeshRenderers => _meshRenderers;
    }
}