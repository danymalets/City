using Sources.Infrastructure.Bootstrap;
using UnityEngine;

namespace Sources.Game.Missions
{
    public class MoveToPointWithoutCarQuest : BoolQuest<MoveToPointProgress>
    {
        private const float DistanceToCompete = 3f;
        
        private readonly ISpawnPoint _target;

        public MoveToPointWithoutCarQuest(ISpawnPoint target)
        {
            _target = target;
        }

        public override void Start()
        {
            
        }

        public override string GetQuestTitle() => "Топ-топ";
        public override string GetQuestDescription() => $"Подойдите к точке";
        
        private Vector3 GetUserPosition() => 
            Vector3.zero;

        protected override bool WasCompleted() => 
            Vector3.Distance(GetUserPosition(), _target.Position) <= DistanceToCompete;
    }
}