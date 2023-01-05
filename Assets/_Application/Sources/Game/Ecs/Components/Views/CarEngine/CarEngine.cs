using Sources.Game.Ecs.Utils;
using Sources.Game.GameObjects.Cars;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views
{
    [RequireComponent(typeof(Rigidbody))]
    public class CarEngine : MonoViewComponent<ICarEngine>, ICarEngine
    {
        private const float BreakTorqueLite = 50;
        private const float BreakTorqueMax = 10000000;

        [SerializeField]
        private AxleInfo[] _axleInfos;

        [SerializeField]
        private float _maxMotorTorque = 500;

        [SerializeField]
        private float _maxSteeringAngle = 40;

        public Vector3 RootPosition =>
            ((_leftWheel.position + _rightWheel.position) / 2).WithY(0);

        private Transform _leftWheel;
        private Transform _rightWheel;
        private Rigidbody _rigidBody;

        public float Speed =>
            transform.InverseTransformDirection(_rigidBody.velocity).z;

        public void SetMaxBreak() => 
            SetBreak(BreakTorqueMax);

        public void SetLiteBreak() => 
            SetBreak(BreakTorqueLite);

        public void ResetBreak() => 
            SetBreak(0);

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
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


        private void SetBreak(float breakForce)
        {
            foreach (AxleInfo axleInfo in _axleInfos)
            {
                axleInfo.leftWheel.brakeTorque = breakForce * (axleInfo.steering ? 70 : 30);
                axleInfo.rightWheel.brakeTorque = breakForce * (axleInfo.steering ? 70 : 30);
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