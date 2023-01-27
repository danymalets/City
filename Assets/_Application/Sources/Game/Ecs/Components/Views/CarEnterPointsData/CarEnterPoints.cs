using System;
using System.Collections.Generic;
using Sources.Infrastructure.Bootstrap;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.CarEnterPointsData
{
    public class CarEnterPoints : MonoBehaviour, ICarEnterPoints
    {
        [SerializeField]
        private EnterPoint[] _enterPoints;

        private void OnValidate()
        {
            _enterPoints = GetComponentsInChildren<EnterPoint>();
        }

        public IEnumerable<IEnterPoint> EnterPoints => _enterPoints;
    }
}