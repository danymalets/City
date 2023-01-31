using System;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Infrastructure.Services.Balance
{
    [CreateAssetMenu(menuName = nameof(Balance) + "/" + nameof(CameraBalance), fileName = nameof(CameraBalance))]
    public class CameraBalance : ScriptableObject
    {
        [SerializeField]
        private float _cameraHeight = 4;

        [SerializeField]
        private float _cameraBackDistance = 6;

        [SerializeField]
        private float _cameraTiltRotationAngle = 30;
        
        [SerializeField]
        private float _cameraFieldOfView = 30;
        
        [FormerlySerializedAs("_cameraRotationСщуаа")]
        [FormerlySerializedAs("_cameraRotationSpeed")]
        [SerializeField]
        private float _cameraRotationCoeff = 90f;
        
        [SerializeField]
        private float _deadAngle = 1f;
        
        public float CameraHeight => _cameraHeight;
        public float CameraBackDistance => _cameraBackDistance;

        public float CameraTiltRotationAngle => _cameraTiltRotationAngle;
        public float CameraFieldOfView => _cameraFieldOfView;
        public float CameraRotationCoeff => _cameraRotationCoeff;
        public float DeadAngle => _deadAngle;
    }
}