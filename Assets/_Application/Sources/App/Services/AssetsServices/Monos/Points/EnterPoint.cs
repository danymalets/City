using Sources.App.Data.Cars;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Monos.Points
{
    public class EnterPoint : MonoBehaviour, IEnterPoint
    {
        public Vector3 Position => transform.position;
        public Quaternion Rotation => transform.rotation;

        [field: SerializeField] public CarSideType SideType { get; private set; }

        private void OnDrawGizmos()
        {
            Gizmos.color = SideType == CarSideType.Left ? Color.green : Color.blue;
            Gizmos.DrawSphere(Position, 0.4f);
            Gizmos.DrawSphere(Position + Rotation * Vector3.forward * 0.4f, 0.2f);
        }
    }
}