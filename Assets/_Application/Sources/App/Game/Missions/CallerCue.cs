using Sources.Data;

namespace Sources.App.Game.Missions
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