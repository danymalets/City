using Sources.App.Data.Points;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Monos.Points
{
    public class MonoPoint : MonoBehaviour, IPoint
    {
        public Vector3 Position => transform.position;
        public Quaternion Rotation => transform.rotation;
    }
}