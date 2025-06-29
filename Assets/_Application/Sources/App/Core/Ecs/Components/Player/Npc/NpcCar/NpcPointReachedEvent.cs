using Scellecs.Morpeh;
using Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes;

namespace Sources.App.Core.Ecs.Components.Player.Npc.NpcCar
{
    public struct NpcPointReachedEvent : IComponent
    {
        public PathPoint Point;
    }
}