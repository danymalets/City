using Sources.AssetsManager;

namespace Sources.App.Game.Missions
{
    public class DialogueCue
    {
        public PlayerType PlayerType { get; }
        private string Phrase { get; }

        public DialogueCue(PlayerType playerType, string phrase)
        {
            PlayerType = playerType;
            Phrase = phrase;
        }
    }
}