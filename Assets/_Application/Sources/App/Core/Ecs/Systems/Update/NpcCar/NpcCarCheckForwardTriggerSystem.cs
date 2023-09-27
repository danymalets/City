using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.InCar;
using Sources.App.Core.Ecs.Components.Player.Npc;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Constants;
using Sources.Services.PhysicsServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.NpcCar
{
    public class NpcCarCheckForwardTriggerSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly IPhysicsService _physics;

        public NpcCarCheckForwardTriggerSystem()
        {
            _physics = DiContainer.Resolve<IPhysicsService>();
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag, PlayerInCar, CheckForwardTriggerRequest>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                Entity carEntity = playerEntity.Get<PlayerInCar>().CarPlaceData.Car;
                ref CarMotorCoefficient carMotorCoefficient = ref carEntity.Get<CarMotorCoefficient>();
                ref CarBreak carBreak = ref carEntity.Get<CarBreak>();
                ref CheckForwardTriggerRequest checkForwardTriggerRequest = ref playerEntity.Get<CheckForwardTriggerRequest>();

                Entity[] entities = _physics.OverlapBox(checkForwardTriggerRequest.Center, checkForwardTriggerRequest.Size / 2, 
                        checkForwardTriggerRequest.Rotation, LayerMasks.CarBordersPlayersEnvironment)
                    .Where(r => r.HasComponent<IEntityAccess>())
                    .Select(r => r.GetComponent<IEntityAccess>().Entity)
                    .Where(e => e != carEntity)
                    .ToArray();

                if (entities.Any())
                {
                    carMotorCoefficient.Coefficient = 0;
                    carBreak.BreakType = BreakType.Max;
                }
                else
                {
                    carMotorCoefficient.Coefficient = 1;
                    carBreak.BreakType = BreakType.None;
                }
            }
        }
    }
}