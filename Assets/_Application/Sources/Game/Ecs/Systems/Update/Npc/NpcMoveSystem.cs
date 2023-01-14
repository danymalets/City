using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views.CarForwardTriggers;
using Sources.Game.Ecs.Components.Views.PlayerDatas;
using Sources.Game.Ecs.Utils.MorpehWrapper;

namespace Sources.Game.Ecs.Systems.Update.Npc
{
    public class NpcMoveSystem : DFixedUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag>().Without<PlayerInCar>();
        }

        protected override void OnFixedUpdate(float fixedDeltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                float speed = npcEntity.GetMono<IPlayerData>().Speed;
                ref PlayerSpeed playerSpeed = ref npcEntity.Get<PlayerSpeed>();
                playerSpeed.Value = speed;
            }
        }
    }
}