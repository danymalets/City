using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Points
{
    public class CameraPoint : MonoPoint, ICameraPoint
    {
        [SerializeField] public float _fieldOfView = 50;

        public float FieldOfView => _fieldOfView;
    }
}