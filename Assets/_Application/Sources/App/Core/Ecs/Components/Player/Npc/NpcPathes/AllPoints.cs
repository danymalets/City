using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Data;
using Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes;

namespace Sources.App.Core.Ecs.Components.Player.Npc.NpcPathes
{
    public struct AllPoints : IComponent
    {
        public List<PathPoint> List { get; set; }
    }
}