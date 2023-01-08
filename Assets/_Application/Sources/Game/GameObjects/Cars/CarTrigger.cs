using UnityEngine;

namespace Sources.Game.GameObjects.Cars
{
    public class CarTrigger : MonoBehaviour
    {
        private int _carsInTrigger;

        public bool HasCarInTrigger =>
            _carsInTrigger > 0;
        
        private void OnEnable()
        {
            _carsInTrigger = 0;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (IsCar(other))
                _carsInTrigger++;
        }

        private void OnTriggerExit(Collider other)
        {
            if (IsCar(other))
                _carsInTrigger--;
        }

        private bool IsCar(Collider other) =>
            !other.isTrigger;
            //&& other.transform.root.GetComponent<Car>() != null;
    }
}