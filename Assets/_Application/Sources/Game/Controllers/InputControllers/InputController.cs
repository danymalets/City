using System.Collections;
using Sources.Data;
using Sources.Data.Live;
using Sources.Game.Controllers.EndController;
using Sources.Infrastructure.Services.CoroutineRunner;
using UnityEngine;

namespace Sources.Game.Controllers.InputControllers
{
    public class InputController
    {
        private readonly LoseController _loseController;
        private readonly WinController _winController;
        
        private readonly CoroutineContext _coroutineContext;

        public InputController()
        {
            _coroutineContext = new CoroutineContext();
            
            _loseController = new LoseController();
            _winController = new WinController();

        }

        public void StartGame()
        {
            _coroutineContext.StartCoroutine(InputCycle());
        }

        private IEnumerator InputCycle()
        {
            while (true)
            {
                yield return null;

                if (Input.GetKeyDown(KeyCode.C))
                {
                    _coins.Value++;
                }
                
                if (Input.GetKeyDown(KeyCode.W))
                {
                    _winController.Win();
                }
                else if (Input.GetKeyDown(KeyCode.L))
                {
                    _loseController.Lose();
                }
            }
        }

        public void Cleanup()
        {
            _coroutineContext.StopAllCoroutines();
        }
    }
}