using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.States.RegistationStates;
using Sources.Services.SceneLoaderServices;
using UnityEngine;

namespace Sources.App.Infrastructure.StateMachine.States.BootstrapStates
{
    [DefaultExecutionOrder(-100)]
    public class BootstrapSceneContext : SceneContext
    {
        [SerializeField]
        private MonoServices _monoServices;

        private void Awake()
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