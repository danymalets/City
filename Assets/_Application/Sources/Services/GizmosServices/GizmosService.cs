using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sources.Services.GizmosServices
{
    public class GizmosService : MonoBehaviour, IGizmosService
    {
        private readonly List<GizmosContext> _contexts = new();
        
        public GizmosContext CreateContext()
        {
            GizmosContext gizmosContext = new(); 
            _contexts.Add(gizmosContext);
            return gizmosContext;
        }

        private void OnDrawGizmos()
        {
            foreach ((Vector3 center, float radius, Color color) in _contexts.SelectMany(c => c.Spheres))
            {
                Gizmos.color = color;
                Gizmos.DrawSphere(center, radius);
            }
            
            foreach ((Vector3 Center, Quaternion Rotation, Vector3 Size, Color Color) in _contexts.SelectMany(c => c.Cubes))
            {
                var defaultMatrix = Gizmos.matrix;
                Gizmos.matrix = Matrix4x4.TRS(Center, Rotation, Size);
                Gizmos.color = Color;
                Gizmos.DrawCube(Vector3.zero, Vector3.one);

                Gizmos.matrix = defaultMatrix;
            }
            
            foreach ((Vector3 Source, Vector3 Target, Color Color) in _contexts.SelectMany(c => c.Lines))
            {
                Gizmos.color = Color;
                Gizmos.DrawLine(Source, Target);
            }
        }
    }
}