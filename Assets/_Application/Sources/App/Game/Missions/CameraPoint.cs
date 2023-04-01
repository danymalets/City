using _Application.Sources.Monos.Bootstrap;
using Sources.App.Infrastructure.Bootstrap;
using UnityEngine;

namespace Sources.App.Game.Missions
{
    public class CameraPoint : SpawnPoint, ICameraPoint
    {
        [SerializeField] public float _fieldOfView = 50;

        public float FieldOfView => _fieldOfView;
    }
}