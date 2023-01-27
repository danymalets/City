using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.User;
using Sources.Game.Ecs.Components.Views.CarEnterPointsData;
using Sources.Game.Ecs.Components.Views.EnableDisable;
using Sources.Game.Ecs.Components.Views.Transform;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Player
{
    public class PlayerCarExitSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag, PlayerInCar, PlayerWantsExitCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                ITransform playerTransform = playerEntity.GetMono<ITransform>();
                IEnableDisableEntity enableDisableEntity = playerEntity.GetMono<IEnableDisableEntity>();

                Entity carEntity = playerEntity.Get<PlayerInCar>().Car;

                IEnterPoint enterPoint = carEntity.GetMono<ICarEnterPoints>().EnterPoints.First();
                
                playerEntity.Remove<PlayerInCar>();

                playerTransform.Position = enterPoint.Position + Vector3.up * 0.3f;
                playerTransform.Rotation = enterPoint.Rotation;
                
                enableDisableEntity.Enable();
            }
        }
    }
}