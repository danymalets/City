using Sources.Utils.CommonUtils.Extensions;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.IdleCarSpawns.Common
{
    public class MapCamera : MonoBehaviour, IMapCamera
    {
        public Vector2 Position
        {
            set => transform.position = new Vector3(value.x, transform.position.y, value.y);
        }

        public float EulerAngleY
        {
            set => transform.rotation = transform.rotation.WithEulerY(value);
        }
    }
}