using System;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.CarEnterPointsData
{
    public class EnterPoint : MonoBehaviour, IEnterPoint
    {
        public Vector3 Position => transform.position;
        public Quaternion Rotation => transform.rotation;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(Position, 0.4f);
        }
    }
}