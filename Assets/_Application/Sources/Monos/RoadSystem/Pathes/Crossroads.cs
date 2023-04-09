using Sources.Data.Pathes;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Monos.RoadSystem.Pathes
{
    public class Crossroads : MonoBehaviour, ICrossroads
    {
        public Road Forward;

        public Road Right;

        public Road Back;

        public Road Left;

        public Road ForwardRelated;
        public Road RightRelated;
        public Road BackRelated;
        public Road LeftRelated;

        public Vector3 Position => transform.position;
        IRoad ICrossroads.Forward => Forward;
        IRoad ICrossroads.Right => Right;
        IRoad ICrossroads.Back => Back;
        IRoad ICrossroads.Left => Left;
        IRoad ICrossroads.ForwardRelated => ForwardRelated;
        IRoad ICrossroads.RightRelated => RightRelated;
        IRoad ICrossroads.BackRelated => BackRelated;
        IRoad ICrossroads.LeftRelated => LeftRelated;
        public IRoad[] GetAllRoads() => new[] { Forward, Left, Back, Right };
        public IRoad[] GetAllRelatedRoads() => new[] { ForwardRelated, RightRelated, BackRelated, LeftRelated };

        private float _oneRoadLength;
    }
}