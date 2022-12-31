using Sources.Game.Characters.NpcStateMachines;
using Sources.Game.GameObjects.Cars;
using UnityEngine;

namespace Sources.Game.Characters
{
    public class NpcAi : MonoBehaviour
    {
        private Car _car;
        private NpcStateMachine _npcStateMachine;

        public void Setup(Car car)
        {
            _car = car;
            _npcStateMachine = new NpcStateMachine(car);
            _npcStateMachine.Enter<DriveByPathState>();
        }
    }
}