using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Components.NavPathes;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Services;
using Sources.App.Data.Cars;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Player
{
    public class PlayerWantsEnterCarHandlerSystem : DUpdateSystem
    {
        private Filter _filter;
        private Filter _carsFilter;
        private readonly INavigationService _navigationService;

        public PlayerWantsEnterCarHandlerSystem()
        {
            _navigationService = DiContainer.Resolve<INavigationService>();
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag, PlayerWantsEnterCarEvent>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                Debug.Log($"player wants");

                CarPlaceData carPlaceData = playerEntity.Get<PlayerWantsEnterCarEvent>().CarPlaceData;

                IEnterPoint enterPoint = carPlaceData.Car.GetRef<IEnterPoint[]>()[carPlaceData.Place];

                if (_navigationService.TryGetPlayerPath(
                        playerEntity.GetRef<IRigidbody>().Position,
                        enterPoint.Position, out Vector3[] path))
                {
                    playerEntity.Set(new PLayerOnNavPath
                    {
                        Path = path,
                        LastCompetedPoint = 0,
                    });

                    playerEntity.Set(new OnNavToCar
                    {
                        PlaceData = carPlaceData
                    });
                    // Debug.Log($"path start:{Vector3.Distance(playerEntity.GetRef<IRigidbody>().Position, path[0])} " +
                    //           $"end:{Vector3.Distance(path[^1], enterPoint.Position)}");
                }
                else
                {
                    playerEntity.Add<OnNavToCarFailedEvent>();
                }
            }
        }
    }
}