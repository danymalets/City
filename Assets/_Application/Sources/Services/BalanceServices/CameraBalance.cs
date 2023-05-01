using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Services.BalanceServices
{
    [CreateAssetMenu(menuName = nameof(Balance) + "/" + nameof(CameraBalance), fileName = nameof(CameraBalance))]
    public class CameraBalance : ScriptableObject
    {
        [Header("Switch System")]
        [SerializeField]
        private float _cameraDeltaSpeed = 3f;
        
        [SerializeField]
        private float _cameraXAngleSpeed = 3f;

        [SerializeField]
        private float _cameraFollowYSpeedCoeff;

        [SerializeField]
        private float _cameraSpeed = 15;

        [Header("Player")]
        [SerializeField]
        private float _cameraPlayerHeight = 4;
        
        [SerializeField]
        private float _cameraPlayerBackDistance = 6;
        
        [SerializeField]
        private float _cameraPlayerXRotationAngle = 30;
        
        [Header("Car")]

        [FormerlySerializedAs("_cameraHeight")]
        [SerializeField]
        private float _cameraCarHeight = 4;

        [FormerlySerializedAs("_cameraBackDistance")]
        [SerializeField]
        private float _cameraCarBackDistance = 6;

        [FormerlySerializedAs("_cameraTiltRotationAngle")]
        [SerializeField]
        private float _cameraCarXRotationAngle = 30;
        
        [SerializeField]
        private float _cameraFieldOfView = 30;
        
        
        [Header("Rotation")]
        [SerializeField]
        private float _cameraRotationCoeff = 90f;
        
        [SerializeField]
        private float _deadAngle = 1f;
        
        public float CameraCarHeight => _cameraCarHeight;
        public float CameraCarBackDistance => _cameraCarBackDistance;

        public float CameraCarXRotationAngle => _cameraCarXRotationAngle;
        public float CameraFieldOfView => _cameraFieldOfView;
        public float CameraRotationCoeff => _cameraRotationCoeff;
        public float DeadAngle => _deadAngle;

        public float CameraPlayerHeight => _cameraPlayerHeight;

        public float CameraPlayerBackDistance => _cameraPlayerBackDistance;

        public float CameraDeltaSpeed => _cameraDeltaSpeed;

        public float CameraXAngleSpeed => _cameraXAngleSpeed;

        public float CameraPlayerXRotationAngle => _cameraPlayerXRotationAngle;

        public float CameraFollowYSpeedCoeff => _cameraFollowYSpeedCoeff;

        public float CameraSpeed => _cameraSpeed;
    }
}