using System.Collections.Generic;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.GameObjects.RoadSystem.Pathes.Points
{
    public class Checkpoint : MonoBehaviour, IConnectingPoint
    {
        public Vector3 Position => transform.position;
        public List<Path> Sources { get; } = new List<Path>();
        public List<Path> Targets { get; }  = new List<Path>();
        public Vector3 Direction => transform.forward;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue.WithAlpha(0.5f);
            Gizmos.DrawSphere(transform.position + Vector3.up * 0.5f, 0.5f);
            Gizmos.DrawSphere(transform.position + transform.forward * 1f + Vector3.up * 0.5f, 
                0.2f);
        }
    }
}