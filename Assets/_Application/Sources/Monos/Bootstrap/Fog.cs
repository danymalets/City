using _Application.Sources.App.Data.Common;
using UnityEngine;

namespace Sources.Monos.Bootstrap
{
    public class Fog : MonoBehaviour, IFog
    {
        [SerializeField]
        private MeshRenderer _firstSphere;

        [SerializeField]
        private MeshRenderer _secondSphere;
        
        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public void SetRadius(float radius)
        {
            _firstSphere.material.SetFloat("_Radius", radius);
            _secondSphere.material.SetFloat("_Radius", radius + 2.5f);
        }
    }
}