using System;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.Camera
{
    public class CameraData : MonoBehaviour, ICameraData
    {
        [SerializeField]
        private UnityEngine.Camera _camera;

        private void OnValidate()
        {
            _camera = GetComponent<UnityEngine.Camera>();
        }

        public float FieldOfView
        {
            get => _camera.fieldOfView;
            set => _camera.fieldOfView = value;
        }
    }
}