using Sources.Game.GameObjects.RoadSystem.Pathes;
using UnityEngine;

namespace Sources.Game.GameObjects.Cars
{
    public class CarData : MonoBehaviour
    {
        private CarEngine _carEngine;
        
        public Path CurrentPath { get; private set; }
        public float DistanceProgress { get; private set; }

        private void Awake()
        {
            _carEngine = GetComponent<CarEngine>();
        }

        public void Setup(Path path, float distanceProgress)
        {
            CurrentPath = path;
            DistanceProgress = distanceProgress;
            
            //transform.position = path.GetPointByDistance(distanceProgress);
            transform.rotation = Quaternion.LookRotation(path.Direction);
        }
    }
}