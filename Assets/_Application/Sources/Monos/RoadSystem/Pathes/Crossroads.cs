using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Data.RoadSystem.Pathes
{
    public class Crossroads : MonoBehaviour
    {
        [FormerlySerializedAs("Up")]
        public Road Forward;

        public Road Right;

        [FormerlySerializedAs("Down")]
        public Road Back;

        public Road Left;

        public Road ForwardRelated;
        public Road RightRelated;
        public Road BackRelated;
        public Road LeftRelated;


        public Road[] GetAllRoads() => new[] { Forward, Left, Back, Right };
        public Road[] GetAllRelatedRoads() => new[] { ForwardRelated, RightRelated, BackRelated, LeftRelated };
        
        private float _oneRoadLength;
    }
}