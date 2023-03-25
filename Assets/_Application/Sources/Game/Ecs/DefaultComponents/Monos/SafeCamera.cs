using System;
using UnityEngine;

namespace Sources.Game.Ecs.DefaultComponents.Monos
{
    [RequireComponent(typeof(Camera))]
    public class SafeCamera : MonoBehaviour, ICamera
    {
        [SerializeField]
        private Camera _camera;

        public float FieldOfView
        {
            get => _camera.fieldOfView;
            set => _camera.fieldOfView = value;
        }

        private void OnValidate()
        {
            _camera = GetComponent<Camera>();
        }
    }
}