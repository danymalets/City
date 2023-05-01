using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.States;
using Sources.App.Services.AssetsServices.Monos.MonoServices;
using Sources.Services.SceneLoaderServices;
using UnityEngine;

namespace Sources.App.Infrastructure
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