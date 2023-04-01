using System.Collections.Generic;
using _Application.Sources.MonoViews;
using UnityEngine;

namespace Sources.App.Game.Components.Old.CarEnterPointsData
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