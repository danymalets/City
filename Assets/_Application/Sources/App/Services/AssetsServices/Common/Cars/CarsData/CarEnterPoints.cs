using System.Collections.Generic;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.Cars.CarsData
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