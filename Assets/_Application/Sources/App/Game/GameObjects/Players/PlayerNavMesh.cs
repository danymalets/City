using UnityEngine;
using UnityEngine.AI;

namespace Sources.App.Game.GameObjects.Players
{
    public class PlayerNavMesh : MonoBehaviour
    {
        private NavMeshPath _path;

        private void Awake()
        {
        }
        
        void Update()
        {
            _path = new NavMeshPath();
            if (GetComponent<NavMeshAgent>().CalculatePath(Vector3.zero, _path))
            {
                Debug.Log(_path.corners.Length);
            }

            GetComponent<NavMeshAgent>().SetPath(_path);
        }

        private void OnDrawGizmos()
        {
            if (_path == null)
                return;
            
            
            Gizmos.color = Color.green;
            for (int i = 0; i < _path.corners.Length - 1; i++)
                Gizmos.DrawLine(_path.corners[i] + Vector3.up, _path.corners[i + 1] + Vector3.up);
        }
    }
}