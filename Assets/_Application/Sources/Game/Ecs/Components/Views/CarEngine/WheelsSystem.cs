using Sources.Game.GameObjects.Cars;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views.CarEngine
{
    public class WheelsSystem : MonoBehaviour
    {
        [SerializeField]
        private AxleInfo[] _axleInfos;
        
        public AxleInfo[] AxleInfo =>
            _axleInfos;
    }
}