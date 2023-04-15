using Sources.App.Data;

namespace Sources.App.Core.Missions
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