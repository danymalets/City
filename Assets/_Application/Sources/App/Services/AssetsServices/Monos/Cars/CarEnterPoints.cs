using System.Collections.Generic;
using Sources.App.Data.Cars;
using Sources.App.Services.AssetsServices.Monos.Points;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Monos.Cars
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