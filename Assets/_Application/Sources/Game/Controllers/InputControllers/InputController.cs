using System.Collections;
using Sources.Data;
using Sources.Data.Live;
using Sources.Game.Controllers.EndController;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.CoroutineRunner;
using Sources.Infrastructure.Services.User;
using UnityEngine;

namespace Sources.Game.Controllers.InputControllers
{
    public class InputController
    {
        private readonly LoseController _loseController;
        private readonly WinController _winController;
        
        private readonly CoroutineContext _coroutineContext;
        private Currency _coins;

        public InputController()
        {
            _coroutineContext = new CoroutineContext();
            
            _loseController = new LoseController();
            _winController = new WinController();

        }

        public void StartGame()
        {
            _coins = DiContainer.Resolve<IUserAccessService>()
                .User.Wallet.Coins;
            _coroutineContext.StartCoroutine(InputCycle());
        }

        private IEnumerator InputCycle()
        {
            while (true)
            {
                yield return null;

                if (Input.GetKeyDown(KeyCode.C))
                {
                    _coins.AddCurrency(1);
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