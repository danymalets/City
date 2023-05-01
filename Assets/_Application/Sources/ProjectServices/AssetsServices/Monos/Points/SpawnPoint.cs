using Sources.App.Data.Points;
using UnityEngine;

namespace Sources.ProjectServices.AssetsServices.Monos.Points
{
    public class SpawnPoint : MonoBehaviour, ISpawnPoint
    {
        public Vector3 Position => transform.position;
        public Quaternion Rotation => transform.rotation;
    }
}