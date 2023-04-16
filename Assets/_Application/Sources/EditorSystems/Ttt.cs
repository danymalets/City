using Sirenix.OdinInspector;
using UnityEngine;

namespace Sources.EditorSystems
{
    public class Ttt : MonoBehaviour
    {
        [Button]
        public void Go()
        {
            GameObject primitive = GameObject.CreatePrimitive(PrimitiveType.Cube);
            primitive.transform.SetParent(transform);
            primitive.transform.localPosition = Vector3.zero;
            primitive.hideFlags = HideFlags.NotEditable;
        }
    }
}