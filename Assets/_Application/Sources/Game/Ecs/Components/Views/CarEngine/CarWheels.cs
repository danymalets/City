using System;
using Sirenix.OdinInspector;
using Sources.Game.GameObjects.Cars;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.CarEngine
{
    [RequireComponent(typeof(Rigidbody))]
    public class CarWheels : MonoBehaviour, ICarWheels
    {
        [SerializeField]
        private WheelsSystem _wheelsSystem;

        public Vector3 RootOffset =>
            transform.InverseTransformPoint(RootPosition);

        public AxleInfo[] AxleInfo =>
            _wheelsSystem.AxleInfo;

        public Vector3 RootPosition => 
            _wheelsSystem.AxleInfo[0].GetRoot();

        private void OnValidate()
        {
            _wheelsSystem = GetComponentInChildren<WheelsSystem>();
        }
    }
}