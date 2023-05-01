using Sources.Services.UserServices.Missions;

namespace Sources.App.Data.Missions.Missions
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
            Progress.QuestsShownCount >= Cues.Length;
    }
}