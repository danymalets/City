using System;
using UnityEngine;

namespace Sources.Infrastructure.Services.Balance
{
    [Serializable]
    public class CameraBalance
    {
        [SerializeField]
        private float _cameraHeight = 5;

        [SerializeField]
        private float _cameraBackDistance = 7;

        public float CameraHeight => _cameraHeight;
        public float CameraBackDistance => _cameraBackDistance;
    }
}