using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sources.Infrastructure.Services.Gizmoses
{
    public class GizmosService : MonoBehaviour, IGizmosService
    {
        private readonly List<(Vector3 Center, float Radius, Color color)> _list = new();

        public void DrawSphere(Vector3 center, float radius, Color color) =>
            _list.Add((center, radius, color));

        private void OnDrawGizmos()
        {
            foreach ((Vector3 center, float radius, Color color) in _list)
            {
                Gizmos.color = color;
                Gizmos.DrawSphere(center, radius);
            }
            
            _list.Clear();
        }
    }
}