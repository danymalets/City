using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.States;
using UnityEngine;

namespace Sources.App.Infrastructure.Bootstrap
{
    [DefaultExecutionOrder(-100)]
    public class EntryPoint : SceneContext
    {
        [SerializeField]
        private MonoServices _monoServices;

        private void Awake()
        {
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