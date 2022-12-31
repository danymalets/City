using UnityEngine;

namespace Sources.Game.GameObjects.Cars
{
    public class WheelGeometry : MonoBehaviour
    {
        [SerializeField]
        private WheelCollider _collider;

        private void Update()
        {
            _collider.GetWorldPose(out Vector3 position, out Quaternion rotation);

            transform.position = position;
            transform.rotation = rotation;
        }
    }
}