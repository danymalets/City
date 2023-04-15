using _Application.Sources.App.Data;

namespace _Application.Sources.App.Core.Missions
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