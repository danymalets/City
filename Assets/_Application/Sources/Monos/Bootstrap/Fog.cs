using UnityEngine;

namespace _Application.Sources.Monos.Bootstrap
{
    public class Fog : MonoBehaviour
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