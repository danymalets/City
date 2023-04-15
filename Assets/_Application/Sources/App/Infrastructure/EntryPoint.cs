using _Application.Sources.App.Infrastructure.StateMachine.Machine;
using _Application.Sources.App.Infrastructure.StateMachine.States;
using _Application.Sources.CommonServices.SceneLoaderServices;
using Sources.Monos.MonoServices;
using UnityEngine;

namespace _Application.Sources.App.Infrastructure
{
    [DefaultExecutionOrder(-1000)]
    public class EntryPoint : SceneContext
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