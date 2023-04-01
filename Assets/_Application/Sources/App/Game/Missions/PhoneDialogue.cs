namespace Sources.App.Game.Missions
{
    public class PhoneDialogue : SubMission<DialogueProgress>
    {
        public PhoneDialogueCue[] Cues { get; }

        public PhoneDialogue(PhoneDialogueCue[] cues)
        {
            Cues = cues;
        }

        public override void Start()
        {
            
        }

        public override bool IsCompleted() =>
            Progress.QuestsSownCount >= Cues.Length;
    }
}