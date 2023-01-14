using System.Collections.Generic;
using UnityEngine;

namespace Sources.Infrastructure.Services.Gizmoses
{
    public class GizmosContext
    {
        private readonly List<(Vector3 Center, float Radius, Color color)> _spheres = new();
        private readonly List<(Vector3 Center, Quaternion Rotation, Vector3 Size, Color Color)> _cubes = new();

        internal IEnumerable<(Vector3 Center, float Radius, Color color)> Spheres => _spheres;
        internal IEnumerable<(Vector3 Center, Quaternion Rotation, Vector3 Size, Color Color)> Cubes => _cubes;
        
        internal GizmosContext()
        {
        }

        public void DrawSphere(Vector3 Center, float Radius, Color color) =>
            _spheres.Add((Center, Radius, color));

        public void DrawCube(Vector3 Center, Quaternion rotation, Vector3 size, Color color) =>
            _cubes.Add((Center, rotation, size, color));

        public void ClearAll()
        {
            _spheres.Clear();
            _cubes.Clear();
        }
    }
}