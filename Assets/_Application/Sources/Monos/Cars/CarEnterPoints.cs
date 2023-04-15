using System.Collections.Generic;
using _Application.Sources.App.Data.Cars;
using Sources.Monos.Points;
using UnityEngine;

namespace Sources.Monos.Cars
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