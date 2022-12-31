using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Sources.GUI
{
    public class RoadCreator : MonoBehaviour
    {
#if UNITY_EDITOR
        
        [SerializeField]
        private RoadSegment _roadSegmentPrefab;

        [SerializeField]
        private float _zDistance = 140f;

        [SerializeField]
        private int _count = 10;

        [Button("CreateEmptyObject")]
        private void CreateRoad()
        {
            foreach (RoadSegment roadSegment in transform.GetComponentsInChildren<RoadSegment>())
                DestroyImmediate(roadSegment.gameObject);

            for (int i = 0; i < _count; i++)
            {
                float z = i * _zDistance;
                
                RoadSegment roadSegment = (RoadSegment)
                    PrefabUtility.InstantiatePrefab(_roadSegmentPrefab);

                roadSegment.transform.position = new Vector3(0, 0, z);
                roadSegment.transform.SetParent(transform);
            }
        }
        
#endif
    }
}