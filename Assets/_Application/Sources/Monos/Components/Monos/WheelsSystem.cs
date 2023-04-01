using Sources.MonoViews;
using Sources.MonoViews.MonoViews;
using UnityEngine;

namespace Sources.Monos.Components.Monos
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