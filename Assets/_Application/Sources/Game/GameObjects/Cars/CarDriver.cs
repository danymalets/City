using UnityEngine;

namespace Sources.Game.GameObjects.Cars
{
    [RequireComponent(typeof(CarEngine))]
    public class CarDriver : MonoBehaviour
    {
        private CarEngine _carEngine;

        private void Awake()
        {
            _carEngine = GetComponent<CarEngine>();

        }

        private void Update()
        {
            float vertical = 0;

            if (Input.GetKey(KeyCode.UpArrow))
                vertical = 1;
            else if (Input.GetKey(KeyCode.DownArrow))
                vertical = -1;
            
            float horizontal = Input.GetAxis("Horizontal");

            bool breaking = Input.GetKey(KeyCode.Space);
            
            _carEngine.SetBreak(breaking);
            
            _carEngine.SetMotorCoefficient(vertical);
            _carEngine.SetAngleCoefficient(horizontal);
        }
    }
}