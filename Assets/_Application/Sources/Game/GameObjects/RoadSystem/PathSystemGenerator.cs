using Sirenix.OdinInspector;
using Sources.Game.GameObjects.RoadSystem.Pathes;
using UnityEditor;
using UnityEngine;

namespace Sources.Game.GameObjects.RoadSystem
{
    public class PathSystemGenerator : MonoBehaviour
    {
        [SerializeField]
        private Crossroads _crossroadsPrefab;

        [SerializeField]
        private Road _roadPrefab;

        [SerializeField]
        private float _islandLength = 30;

        [SerializeField]
        private float _roadLength = 6;

        [SerializeField]
        private int _xRoadsCount = 4;

        [SerializeField]
        private int _zRoadsCount = 4;

        [Button("GENERATE")]
        private void Generate()
        {
            foreach (Transform child in transform)
            {
                DestroyImmediate(child);
            }
            
            float xLength = _xRoadsCount * _roadLength + (_xRoadsCount - 1) * _islandLength;
            float zLength = _zRoadsCount * _roadLength + (_zRoadsCount - 1) * _islandLength;

            int xTotalCount = _xRoadsCount + _xRoadsCount - 1;
            int zTotalCount = _zRoadsCount + _zRoadsCount - 1;

            Road[,] roadsMatrix = new Road[xTotalCount,zTotalCount];

            float x0 = -xLength / 2;
            float z0 = -zLength / 2;

            Transform crossroadsRoot = new GameObject("Crossroads").transform;
            crossroadsRoot.SetParent(transform);
            
            Transform roadsRoot = new GameObject("Roads").transform;
            roadsRoot.SetParent(transform);
            
            for (int xi = 0; xi < xTotalCount; xi += 2)
            {
                for (int zi = 1; zi < zTotalCount; zi += 2)
                {
                    Road road = Instantiate(_roadPrefab, roadsRoot);

                    road.transform.position = new Vector3(
                        x0 + xi / 2 * (_islandLength + _roadLength) + _roadLength / 2, 0, 
                        z0 + zi / 2 * (_islandLength + _roadLength) + _islandLength / 2 + _roadLength);
                    
                    roadsMatrix[xi, zi] = road;
                }
            }
            
            for (int xi = 1; xi < xTotalCount; xi += 2)
            {
                for (int zi = 0; zi < zTotalCount; zi += 2)
                {
                    Road road = Instantiate(_roadPrefab, roadsRoot);

                    road.transform.position = new Vector3(
                        x0 + xi / 2 * (_islandLength + _roadLength) + _islandLength / 2 + _roadLength, 0, 
                        z0 + zi / 2 * (_islandLength + _roadLength) + _roadLength / 2);

                    road.transform.eulerAngles = new Vector3(0, 90, 0);
                    
                    roadsMatrix[xi, zi] = road;
                }
            }
            
            for (int xi = 0; xi < xTotalCount; xi += 2)
            {
                for (int zi = 0; zi < zTotalCount; zi += 2)
                {
                    Crossroads crossroads = Instantiate(_crossroadsPrefab, crossroadsRoot);
                    
                    crossroads.transform.position = new Vector3(
                        x0 + xi / 2f * (_islandLength + _roadLength) + _roadLength / 2, 0, 
                        z0 + zi / 2f * (_islandLength + _roadLength) + _roadLength / 2);

                    if (xi - 1 >= 0)
                        crossroads.Left = roadsMatrix[xi - 1, zi];
                    
                    if (zi - 1 >= 0)
                        crossroads.Down = roadsMatrix[xi, zi - 1];
                    
                    if (xi + 1 < xTotalCount)
                        crossroads.Right = roadsMatrix[xi + 1, zi];
                    
                    if (zi + 1 < zTotalCount)
                        crossroads.Up = roadsMatrix[xi, zi + 1];
                }
            }
        }
    }
}