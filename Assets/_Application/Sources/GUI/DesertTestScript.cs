using Sirenix.OdinInspector;
using UnityEngine;

namespace Sources.GUI
{
    public class DesertTestScript : MonoBehaviour
    {
        [Button("Go")]
        private void Go()
        {
            foreach (Transform t in transform)
            {
                if (t.position.x > 0) 
                    t.position += Vector3.right;
                else 
                    t.position -= Vector3.right;
            }
        }
    }
}