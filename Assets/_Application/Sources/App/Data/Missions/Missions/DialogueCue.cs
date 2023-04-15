namespace Sources.App.Data.Missions.Missions
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