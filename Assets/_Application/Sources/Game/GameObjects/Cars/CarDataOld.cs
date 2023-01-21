using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Components.Views.CarEngine;
using Sources.Game.GameObjects.RoadSystem.Pathes;
using UnityEngine;

namespace Sources.Game.GameObjects.Cars
{
    public class CarDataOld : MonoBehaviour
    {
        private CarWheels _carWheels;
        
        public PathLine CurrentPathLine { get; private set; }
        public float DistanceProgress { get; private set; }

        private void Awake()
        {
            _carWheels = GetComponent<CarWheels>();
        }

        public void Setup(PathLine pathLine, float distanceProgress)
        {
            CurrentPathLine = pathLine;
            DistanceProgress = distanceProgress;
            
            //transform.position = pathLine.GetPointByDistance(distanceProgress);
            transform.rotation = Quaternion.LookRotation(pathLine.Direction);
        }
    }
}