using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.GameObjects.Cars
{
    [RequireComponent(typeof(Rigidbody))]
    public class CarEngine : MonoBehaviour
    {
        private const float BreakTorque = 10000000;

        [SerializeField]
        private AxleInfo[] _axleInfos;
        public float _maxMotorTorque;
        public float _maxSteeringAngle;
        
        public Vector3 RootPosition =>
            ((_leftWheel.position + _rightWheel.position) / 2).WithY(0);

        private Transform _leftWheel;
        private Transform _rightWheel;

        private void Awake()
        {
            foreach (AxleInfo axleInfo in _axleInfos)
            {
                if (axleInfo.steering)
                {
                    _leftWheel = axleInfo.leftWheel.transform;
                    _rightWheel = axleInfo.rightWheel.transform;
                }
            }
        }

        public void SetAngleCoefficient(float angleCoefficient) => 
            SetAngle(angleCoefficient * _maxSteeringAngle);

        public void SetMotorCoefficient(float motorCoefficient)
        {
            float motor = motorCoefficient * _maxMotorTorque;

            foreach (AxleInfo axleInfo in _axleInfos)
            {
                if (axleInfo.motor)
                {
                    axleInfo.leftWheel.motorTorque = motor;
                    axleInfo.rightWheel.motorTorque = motor;
                }
            }
        }

        public void SetBreak(bool enabled)
        {
            foreach (AxleInfo axleInfo in _axleInfos)
            {
                if (enabled)
                {
                    axleInfo.leftWheel.brakeTorque = BreakTorque * (axleInfo.steering ? 70 : 30);
                    axleInfo.rightWheel.brakeTorque = BreakTorque * (axleInfo.steering ? 70 : 30);
                }
                else
                {
                    axleInfo.leftWheel.brakeTorque = 0;
                    axleInfo.rightWheel.brakeTorque = 0;
                }
            }
        }

        public void TrySetAngle(float angle) =>
            SetAngle(Mathf.Clamp(angle, -_maxSteeringAngle, _maxSteeringAngle));

        private void SetAngle(float angle)
        {
            foreach (AxleInfo axleInfo in _axleInfos)
            {
                if (axleInfo.steering)
                {
                    axleInfo.leftWheel.steerAngle = angle;
                    axleInfo.rightWheel.steerAngle = angle;
                }
            }
        }
    }
}