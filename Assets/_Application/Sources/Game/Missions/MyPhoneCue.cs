namespace Sources.Game.Missions
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