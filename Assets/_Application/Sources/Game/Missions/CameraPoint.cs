using Sources.Infrastructure.Bootstrap;
using UnityEngine;

namespace Sources.Game.Missions
{
    public class CameraPoint : SpawnPoint, ICameraPoint
    {
        [SerializeField] public float _fieldOfView = 50;

        public float FieldOfView => _fieldOfView;
    }
}