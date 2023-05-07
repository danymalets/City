using UnityEngine;

namespace Sources.Utils.MorpehWrapper.DefaultComponents.Views
{
    public interface IRigidbody
    {
        float SignedSpeed { get; }
        Vector3 Velocity { get; set; }
        Vector3 LocalVelocity { get; set; }
        Vector3 Position { get; set; }
        Quaternion Rotation { get; set; }
        Vector3 CenterMass { get; set; }
        void ResetCenterOfMass();
        RigidbodyConstraints Constraints { get; set; }
        float Mass { get; set; }
        RigidbodyInterpolation Interpolation { get; set; }
        void MoveRotation(Quaternion rotation);
    }
}