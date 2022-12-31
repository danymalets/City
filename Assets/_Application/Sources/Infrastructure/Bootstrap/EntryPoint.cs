using Sources.Infrastructure.StateMachine.Machine;
using Sources.Infrastructure.StateMachine.States;
using Sources.UI.System;
using UnityEngine;

namespace Sources.Infrastructure.Bootstrap
{
    public class EntryPoint : SceneData
    {
        [SerializeField]
        private UiSystem _uiSystem;

        [SerializeField]
        private MonoServices _monoServices;

        private void Start()
        {
            StartGameStateMachine();
        }
        
        private void StartGameStateMachine()
        {
            GameStateMachine gameStateMachine = new();
            gameStateMachine.Enter<BootstrapStateBase, UiSystem, MonoServices>(_uiSystem, _monoServices);
        }
    }
}