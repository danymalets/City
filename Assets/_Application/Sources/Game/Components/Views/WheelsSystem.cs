using Sources.Game.GameObjects.Cars;
using UnityEngine;

namespace Sources.Game.Components.Views
{
    public class WheelsSystem : MonoBehaviour, IWheelsSystem
    {
        [SerializeField]
        private AxleInfo[] _axleInfos;
        
        public AxleInfo[] AxleInfo =>
            _axleInfos;
        
        public Vector3 RootOffset =>
            transform.InverseTransformPoint(RootPosition);
        
        public Vector3 RootPosition => 
            AxleInfo[0].GetRoot();
    }
}