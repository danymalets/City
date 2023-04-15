namespace _Application.Sources.App.Core.Missions
{
    public class WalkDistanceQuest : FloatQuest<WalkDistanceProgress>
    {
        private readonly float _requiredDistance;

        public WalkDistanceQuest(float requiredDistance)
        {
            _requiredDistance = requiredDistance;
        }

        public override void Start()
        {
            
        }

        protected override float GetCompletedValue() => Progress.WalkedDistance;
        protected override float GetRequiredValue() => _requiredDistance;
        public override string GetQuestTitle() => "Пешеход";
        public override string GetQuestDescription() => $"Пройдите {_requiredDistance} м.";
    }
}