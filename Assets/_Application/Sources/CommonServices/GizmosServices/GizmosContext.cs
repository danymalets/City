using System.Collections.Generic;
using UnityEngine;

namespace Sources.CommonServices.GizmosServices
{
    public class GizmosContext
    {
        private readonly List<(Vector3 Center, float Radius, Color color)> _spheres = new();
        private readonly List<(Vector3 Center, Quaternion Rotation, Vector3 Size, Color Color)> _cubes = new();
        private readonly List<(Vector3 Source, Vector3 Targe, Color Color)> _lines = new();

        internal IEnumerable<(Vector3 Center, float Radius, Color color)> Spheres => _spheres;
        internal IEnumerable<(Vector3 Center, Quaternion Rotation, Vector3 Size, Color Color)> Cubes => _cubes;
        internal IEnumerable<(Vector3 Source, Vector3 Target, Color Color)> Lines => _lines;
        
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
            _lines.Clear();
        }

        public void DrawLine(Vector3 source, Vector3 target, Color color) => 
            _lines.Add((source, target, color));
    }
}