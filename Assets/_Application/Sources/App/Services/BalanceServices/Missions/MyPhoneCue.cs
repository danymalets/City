namespace Sources.App.Services.BalanceServices.Missions
{
    public class MyPhoneCue : PhoneDialogueCue
    {
        private string Phrase { get; }

        public MyPhoneCue(string phrase)
        {
            Phrase = phrase;
        }
    }
}