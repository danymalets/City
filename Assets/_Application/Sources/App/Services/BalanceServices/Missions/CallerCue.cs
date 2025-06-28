using Sources.App.Services.AssetsServices.Common.Monos.Players;

namespace Sources.App.Services.BalanceServices.Missions
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