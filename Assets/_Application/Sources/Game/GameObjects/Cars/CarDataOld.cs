using Sources.Game.Ecs.Components.Views;
using Sources.Game.GameObjects.RoadSystem.Pathes;
using UnityEngine;

namespace Sources.Game.GameObjects.Cars
{
    public class CarDataOld : MonoBehaviour
    {
        private CarWheels _carWheels;
        
        public Path CurrentPath { get; private set; }
        public float DistanceProgress { get; private set; }

        private void Awake()
        {
            _carWheels = GetComponent<CarWheels>();
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