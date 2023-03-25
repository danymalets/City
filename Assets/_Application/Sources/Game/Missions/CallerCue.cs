using Sources.Infrastructure.Services.AssetsManager;

namespace Sources.Game.Missions
{
    public class CallerCue : PhoneDialogueCue
    {
        public PlayerType PlayerType { get; }
        private string Phrase { get; }

        public CallerCue(PlayerType playerType, string phrase)
        {
            PlayerType = playerType;
            Phrase = phrase;
        }
    }
}