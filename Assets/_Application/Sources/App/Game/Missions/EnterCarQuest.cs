using Sources.Data;
using Sources.Data.Cars;

namespace Sources.App.Game.Missions
{
    public class EnterCarQuest : BoolQuest<BoolQuestProgress>
    {
        private readonly CarType _carType;

        public EnterCarQuest(CarType carType)
        {
            _carType = carType;
        }

        public override void Start()
        {
            
        }

        public override string GetQuestTitle() => "Шофёр";
        public override string GetQuestDescription() => $"Сядьте в машину";
        protected override bool WasCompleted() => Progress.Completed;
    }
}