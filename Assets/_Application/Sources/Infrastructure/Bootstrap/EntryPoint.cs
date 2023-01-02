using Sources.Infrastructure.StateMachine.Machine;
using Sources.Infrastructure.StateMachine.States;
using Sources.UI.System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Infrastructure.Bootstrap
{
    public class EntryPoint : SceneContext
    {
        [SerializeField]
        private MonoServices _monoServices;

        private void Start()
        {
            StartGameStateMachine();
        }
        
        private void StartGameStateMachine()
        {
            GameStateMachine gameStateMachine = new();
            gameStateMachine.Enter<RegistrationState, MonoServices>(_monoServices);
        }
    }
}