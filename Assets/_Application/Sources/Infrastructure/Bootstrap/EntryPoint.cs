using Sources.Infrastructure.StateMachine.Machine;
using Sources.Infrastructure.StateMachine.States;
using Sources.UI.System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Infrastructure.Bootstrap
{
    [DefaultExecutionOrder(-100)]
    public class EntryPoint : SceneContext
    {
        [SerializeField]
        private MonoServices _monoServices;

        protected override void Awake()
        {
            base.Awake();
            
            if (Application.isPlaying)
                StartGameStateMachine();
        }
        
        private void StartGameStateMachine()
        {
            GameStateMachine gameStateMachine = new();
            gameStateMachine.Enter<RegistrationState, MonoServices>(_monoServices);
        }
    }
}