using Sources.Services.UserServices.Missions;

namespace Sources.App.Data.Missions.Missions
{
    public class DialogueScene : SubMission<DialogueProgress>
    {
        public DialogueCamera Camera { get; }
        public DialogueCue[] Cues { get; }

        public DialogueScene(DialogueCamera dialogueCamera, DialogueCue[] cues)
        {
            Camera = dialogueCamera;
            Cues = cues;
        }

        public override void Start()
        {
            
        }

        public override bool IsCompleted() =>
            Progress.QuestsShownCount >= Cues.Length;
    }
}