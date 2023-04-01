using UnityEngine;

namespace Sources.App.Game.Ecs.DefaultComponents.Views
{
    public interface IRigidbody
    {
        float SignedSpeed { get; }
        Vector3 Velocity { get; set; }
        Vector3 LocalVelocity { get; set; }
        Vector3 Position { get; set; }
        Quaternion Rotation { get; set; }
        bool DetectCollisions { get; set; }
        bool IsKinematic { get; set; }
        Vector3 CenterMass { get; set; }
        
        RigidbodyConstraints Constraints { get; set; }
        float Mass { get; set; }
        RigidbodyInterpolation Interpolation { get; set; }
        void MakeKinematic();
        void MakePhysical();
        void MoveRotation(Quaternion rotation);
    }
}