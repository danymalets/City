using System;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using UnityEngine;

namespace Sources.Utils.MorpehWrapper.DefaultComponents.Monos
{
    [RequireComponent(typeof(Rigidbody))]
    public class SafeRigidbody : SafeComponent<Rigidbody>, IRigidbody
    {
        public float SignedSpeed =>
            LocalVelocity.z;

        public Vector3 Velocity
        {
            get => Unsafe.velocity;
            set => Unsafe.velocity = value;
        }

        public Vector3 LocalVelocity
        {
            get => Unsafe.transform.InverseTransformDirection(Unsafe.velocity);
            set => Unsafe.velocity = Unsafe.transform.TransformDirection(value);
        }

        public Vector3 Position
        {
            get => Unsafe.position;
            set => Unsafe.position = value;
        }

        public Quaternion Rotation
        {
            get => Unsafe.rotation;
            set => Unsafe.rotation = value;
        }

        public RigidbodyInterpolation Interpolation
        {
            get => Unsafe.interpolation;
            set => Unsafe.interpolation = value;
        }

        public bool DetectCollisions
        {
            get => Unsafe.detectCollisions;
            set => Unsafe.detectCollisions = value;
        }

        public bool IsKinematic
        {
            get => Unsafe.isKinematic;
            set => Unsafe.isKinematic = value;
        }

        public void MakeKinematic() =>
            Unsafe.isKinematic = true;

        public void MakePhysical() =>
            Unsafe.isKinematic = false;

        public void MoveRotation(Quaternion rotation) =>
            Unsafe.MoveRotation(rotation);

        public Vector3 CenterMass
        {
            get => Unsafe.centerOfMass;
            set => Unsafe.centerOfMass = value;
        }

        public void ResetCenterOfMass() =>
            Unsafe.ResetCenterOfMass();

        public RigidbodyConstraints Constraints
        {
            get => Unsafe.constraints;
            set => Unsafe.constraints = value;
        }

        public float Mass
        {
            get => Unsafe.mass;
            set => Unsafe.mass = value;
        }
    }
}