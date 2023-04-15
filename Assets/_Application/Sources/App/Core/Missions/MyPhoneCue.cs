namespace _Application.Sources.App.Core.Missions
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