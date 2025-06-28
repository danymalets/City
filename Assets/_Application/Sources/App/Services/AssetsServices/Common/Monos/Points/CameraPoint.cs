using Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Points;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.Monos.Points
{
    public class CameraPoint : MonoPoint, ICameraPoint
    {
        [SerializeField] public float _fieldOfView = 50;

        public float FieldOfView => _fieldOfView;
    }
}