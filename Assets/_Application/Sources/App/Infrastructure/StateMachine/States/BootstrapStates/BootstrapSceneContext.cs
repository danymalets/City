using Sources.App.Infrastructure.StateMachine.Machine;
using Sources.App.Infrastructure.StateMachine.States.InitializationStates;
using Sources.Services.SceneLoaderServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Sources.App.Infrastructure.StateMachine.States.BootstrapStates
{
    [DefaultExecutionOrder(-100)]
    public class BootstrapSceneContext : SceneContext
    {
        [FormerlySerializedAs("_gameObjectsData")] [FormerlySerializedAs("_monoServicesData")] [SerializeField]
        private GameObjectsInitializationData _gameObjectsInitializationData;

        private void Awake()
        {
            StartGameStateMachine();
        }

        private void StartGameStateMachine()
        {
            GameStateMachine gameStateMachine = new();
            gameStateMachine.Enter<InitializationState, GameObjectsInitializationData>(_gameObjectsInitializationData);
        }
    }
}