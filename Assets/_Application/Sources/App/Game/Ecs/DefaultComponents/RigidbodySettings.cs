using UnityEngine;

namespace Sources.App.Game.Ecs.DefaultComponents
{
    public class RigidbodySettings
    {
        public float Mass { get; }
        public RigidbodyConstraints RigidbodyConstraints { get; }
        public Vector3? CenterOfMass { get; }

        public RigidbodySettings(float mass, RigidbodyConstraints rigidbodyConstraints, Vector3? centerOfMass)
        {
            Mass = mass;
            RigidbodyConstraints = rigidbodyConstraints;
            CenterOfMass = centerOfMass;
        }
    }
}