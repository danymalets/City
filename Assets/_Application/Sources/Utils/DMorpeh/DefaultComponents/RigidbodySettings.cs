using UnityEngine;

namespace Sources.Utils.DMorpeh.DefaultComponents
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