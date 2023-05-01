using Sources.App.Data.Points;
using UnityEngine;

namespace Sources.Services.AssetsServices.Monos.Points
{
    public class CameraPoint : SpawnPoint, ICameraPoint
    {
        [SerializeField] public float _fieldOfView = 50;

        public float FieldOfView => _fieldOfView;
    }
}