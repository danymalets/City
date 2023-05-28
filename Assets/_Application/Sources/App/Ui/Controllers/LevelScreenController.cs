using Sources.App.Ui.Screens.Level;

namespace Sources.App.Ui.Controllers
{
    public class LevelScreenController : ScreenController
    {
        private readonly LevelScreen _gameScreen;

        public CoinsViewController CoinsViewController { get; private set; }

        public LevelScreenController(LevelScreen gameScreen) : 
            base(new DefaultPopupAnimator(gameScreen))
        {
            _gameScreen = gameScreen;

            CoinsViewController = new CoinsViewController(gameScreen.CoinsView);
        }

        protected override void OnOpen()
        {
            
        }

        protected override void OnClose()
        {
            
        }

        protected override void OnRefresh()
        {
            
        }
    }

    public class CoinsViewController
    {
        private readonly CoinsView _coinsView;
        
        public CoinsViewController(CoinsView coinsView)
        {
            _coinsView = coinsView;
        }
    }
}