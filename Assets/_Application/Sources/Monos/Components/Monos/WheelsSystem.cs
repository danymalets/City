using Sources.Data.MonoViews;
using Sources.Data.MonoViews.MonoViews;
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

        public void EnableSystem() =>
            SetSystemEnabled(true);
        
        public void DisableSystem() =>
            SetSystemEnabled(false);

        public void SetSystemEnabled(bool enabled)
        {
            foreach (AxleInfo axleInfo in _axleInfos)
            {
                axleInfo.LeftWheelCollider.gameObject.SetActive(enabled);
                axleInfo.RightWheelCollider.gameObject.SetActive(enabled);
            }
        }
    }
}