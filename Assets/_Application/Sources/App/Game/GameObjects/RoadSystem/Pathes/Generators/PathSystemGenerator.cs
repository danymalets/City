using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Sources.App.Game.GameObjects.RoadSystem.Pathes.Generators
{
    public class PathSystemGenerator : MonoBehaviour
    {
        [SerializeField]
        private PathSystem _relatedPathSystem;

        [SerializeField]
        private float _relatedCrossroadsSize = 3;

        [SerializeField]
        private Crossroads _crossroadsPrefab;

        [SerializeField]
        private Road _roadEvenPrefab;

        [SerializeField]
        private Road _roadOddPrefab;
        
        [SerializeField]
        private float _roadEvenVerticalLength = 30;

        [SerializeField]
        private float _roadOddVerticalLength = 30;

        [SerializeField]
        private float _roadHorizontalLength = 6;

        [SerializeField]
        private int _xRoadsCount = 4;

        [SerializeField]
        private int _zRoadsCount = 4;

        private float GetVerticalLengthSum(int firstCount)
        {
            float sum = 0;
            for (int i = 0; i < firstCount; i++)
            {
                sum += GetVerticalLength(i);
            }
            return sum;
        }

        private float GetVerticalLength(int i) => 
            i % 2 == 0 ? _roadEvenVerticalLength : _roadOddVerticalLength;

        private Road GetRoadPrefab(int i) => 
            i % 2 == 0 ? _roadEvenPrefab : _roadOddPrefab;

        [Button("CLEAR", ButtonSizes.Large)]
        private void Clear()
        {
            foreach (Transform child in transform)
            {
                DestroyImmediate(child.gameObject);
            }
        }

        [Button("GENERATE", ButtonSizes.Large)]
        private void Generate()
        {
            float xLength = _roadHorizontalLength * _xRoadsCount + GetVerticalLengthSum(_xRoadsCount - 1);
            float zLength = _roadHorizontalLength * _zRoadsCount + GetVerticalLengthSum(_zRoadsCount - 1);

            // Debug.Log($"{zLength} {zLength} - size");
            
            int xTotalCount = _xRoadsCount + _xRoadsCount - 1;
            int zTotalCount = _zRoadsCount + _zRoadsCount - 1;

            Road[,] roadsMatrix = new Road[xTotalCount, zTotalCount];

            float x0 = -xLength / 2;
            float z0 = -zLength / 2;

            GenerateRoads(xTotalCount, zTotalCount, x0, z0, roadsMatrix);

            GenerateCrossroads(xTotalCount, zTotalCount, x0, z0, roadsMatrix);
        }

        private void GenerateRoads(int xTotalCount, int zTotalCount, float x0, float z0, Road[,] roadsMatrix)
        {
            Transform roadsRoot = new GameObject("Roads").transform;
            roadsRoot.SetParent(transform);

            for (int xi = 0; xi < xTotalCount; xi += 2)
            {
                for (int zi = 1; zi < zTotalCount; zi += 2)
                {
                    Road road = Instantiate(GetRoadPrefab(zi / 2), roadsRoot);

                    road.transform.position = new Vector3(
                        x0 + (xi / 2 + 0.5f) * _roadHorizontalLength + GetVerticalLengthSum(xi / 2), 0,
                        z0 + GetVerticalLengthSum(zi / 2) + GetVerticalLength(zi / 2) / 2 + (zi / 2 + 1) *
                        _roadHorizontalLength);

                    roadsMatrix[xi, zi] = road;
                }
            }

            for (int xi = 1; xi < xTotalCount; xi += 2)
            {
                for (int zi = 0; zi < zTotalCount; zi += 2)
                {
                    Road road = Instantiate(GetRoadPrefab(xi / 2), roadsRoot);

                    road.transform.position = new Vector3(
                        x0 + GetVerticalLengthSum(xi / 2) + GetVerticalLength(xi / 2) / 2 + (xi / 2 + 1) *
                        _roadHorizontalLength, 0,
                        z0 + (zi / 2 + 0.5f) * _roadHorizontalLength + GetVerticalLengthSum(zi / 2));

                    road.transform.eulerAngles = new Vector3(0, 90, 0);

                    roadsMatrix[xi, zi] = road;
                }
            }
        }

        private void GenerateCrossroads(int xTotalCount, int zTotalCount, float x0, float z0, Road[,] roadsMatrix)
        {
            Transform crossroadsRoot = new GameObject("Crossroads").transform;
            crossroadsRoot.SetParent(transform);

            Road[] relatedRoads = Array.Empty<Road>();

            if (_relatedPathSystem != null)
                relatedRoads = _relatedPathSystem.GetComponentsInChildren<Road>();
            
            for (int xi = 0; xi < xTotalCount; xi += 2)
            {
                for (int zi = 0; zi < zTotalCount; zi += 2)
                {
                    Crossroads crossroads = Instantiate(_crossroadsPrefab, crossroadsRoot);

                    crossroads.transform.position = new Vector3(
                        x0 + GetVerticalLengthSum(xi / 2) + +_roadHorizontalLength * (xi / 2 + 0.5f), 0,
                        z0 + GetVerticalLengthSum(zi / 2) + +_roadHorizontalLength * (zi / 2 + 0.5f));

                    if (xi - 1 >= 0)
                        crossroads.Left = roadsMatrix[xi - 1, zi];

                    if (zi - 1 >= 0)
                        crossroads.Back = roadsMatrix[xi, zi - 1];

                    if (xi + 1 < xTotalCount)
                        crossroads.Right = roadsMatrix[xi + 1, zi];

                    if (zi + 1 < zTotalCount)
                        crossroads.Forward = roadsMatrix[xi, zi + 1];

                    Vector3 mainPosition = crossroads.transform.position;
                    float delta = (_roadHorizontalLength + _relatedCrossroadsSize) / 2;

                    if (TryGetRelated(relatedRoads, mainPosition + Vector3.forward * delta, out Road fRoad))
                    {
                        crossroads.ForwardRelated = fRoad;
                    }

                    if (TryGetRelated(relatedRoads, mainPosition + Vector3.left * delta, out Road lRoad))
                    {
                        crossroads.LeftRelated = lRoad;
                    }

                    if (TryGetRelated(relatedRoads, mainPosition + Vector3.back * delta, out Road bRoad))
                    {
                        crossroads.BackRelated = bRoad;
                    }

                    if (TryGetRelated(relatedRoads, mainPosition + Vector3.right * delta, out Road rRoad))
                    {
                        crossroads.RightRelated = rRoad;
                    }
                }
            }
        }

        private bool TryGetRelated(Road[] roads, Vector3 position, out Road result)
        {
            foreach (Road crossroads in roads) 
            {
                if (Vector3.Distance(crossroads.transform.position, position) < 3f)
                {
                    result = crossroads;
                    return true;
                }
            }
            result = default;
            return false;
        }
    }
}