using UnityEngine;

namespace Sources.Game.GameObjects.RoadSystem.Pathes
{
    public class Crossroads : MonoBehaviour
    {
        public Road Up;

        public Road Right;

        public Road Down;

        public Road Left;
        
        public Road[] GetAllRoads() => new[] { Up, Left, Down, Right };
        
        private float _oneRoadLength;
    }
}