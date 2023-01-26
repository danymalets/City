using UnityEngine;

namespace Sources.Infrastructure.Bootstrap
{
    public class Fog : MonoBehaviour
    {
        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
    }
}