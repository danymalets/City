using Sources.App.Data.Pathes;
using Sources.App.Data.Points;
using Sources.Utils.CommonUtils.Extensions;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Monos.RoadSystem.Pathes.Points
{
    public class RoadLaneCheckpoint : MonoBehaviour, IRoadLaneCheckpoint
    {
        public Vector3 Position => transform.position;
        
        public Point RelatedPoint { get; set; }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue.WithAlpha(0.5f);
            Gizmos.DrawSphere(transform.position + Vector3.up * 0.5f, 0.5f);
            Gizmos.DrawSphere(transform.position + transform.forward * 1f + Vector3.up * 0.5f, 
                0.2f);
        }
    }
}