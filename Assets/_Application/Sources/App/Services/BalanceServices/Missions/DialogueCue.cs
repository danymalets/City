using Sources.App.Services.AssetsServices.Common.Players.PlayersData;

namespace Sources.App.Services.BalanceServices.Missions
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