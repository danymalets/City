using Sources.Game.GameObjects.Cars;
using UnityEngine;

namespace Sources.Game.Characters
{
    public class PlayerInput : MonoBehaviour
    {
        private Car _car;

        public void Setup(Car car)
        {
            _car = car;    
        }
        
        private void Update()
        {
            float vertical = 0;

            if (Input.GetKey(KeyCode.UpArrow))
                vertical = 1;
            else if (Input.GetKey(KeyCode.DownArrow))
                vertical = -1;
            
            float horizontal = Input.GetAxis("Horizontal");
            
            _car.SetMotorCoefficient(vertical);
            _car.SetAngleCoefficient(horizontal);
        }
    }
}