using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services.Balance;
using UnityEngine;

namespace Sources.Game.Missions
{
    public class MoveToPointByCarQuest : BoolQuest<MoveToPointProgress>
    {
        private const float DistanceToCompete = 3f;
        
        private readonly ISpawnPoint _target;

        public MoveToPointByCarQuest(ISpawnPoint target)
        {
            _target = target;
        }

        public override void Start()
        {
            
        }

        public override string GetQuestTitle() => "Сквозь тернии";
        public override string GetQuestDescription() => $"Доберитесь на машине до точки";
        
        private Vector3 GetUserPosition() => 
            Vector3.zero;

        protected override bool WasCompleted() => 
            Vector3.Distance(GetUserPosition(), _target.Position) <= DistanceToCompete;
    }
    
    public class BringPeopleQuest : IntQuest<BringPeopleProgress>
    {
        private readonly int _requiredBrought;
        private const float DistanceToCompete = 3f;
        
        private readonly ISpawnPoint _target;

        public BringPeopleQuest(int requiredBrought)
        {
            _requiredBrought = requiredBrought;
        }

        public override void Start()
        {
            
        }

        public override string GetQuestTitle() => "Таксист";
        public override string GetQuestDescription() => $"Подвезите {_requiredBrought} людей";

        protected override int GetCompletedValue() =>
            Progress.BroughtCount;

        protected override int GetRequiredValue() => 
            _requiredBrought;
    }

    public class BringPeopleProgress : SubMissionProgress
    {
        public int BroughtCount { get; set; }
    }
}