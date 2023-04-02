using Sources.Data;
using Sources.Monos.Bootstrap;
using UnityEngine;

namespace Sources.App.Game.Missions
{
    public class CameraPoint : SpawnPoint, ICameraPoint
    {
        [SerializeField] public float _fieldOfView = 50;

        public float FieldOfView => _fieldOfView;
    }
}