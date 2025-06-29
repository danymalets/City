using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player.Npc.NpcPathes;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Data;
using Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;

namespace Sources.App.Core.Ecs.Factories
{
    public class PathesFactory : Factory, IPathesFactory
    {
        public Entity CreatePathes<TTag, TRelatedAreaTag>(IPathSystem pathSystem) 
            where TTag : struct, IComponent 
            where TRelatedAreaTag : struct, IComponent
        {
            return _world.CreateEntity()
                .Add<TTag>()
                .Add<PathesTag>()
                .Set(new RelatedSimulationArea() { SimulationAreaEntity = _world.Filter<TRelatedAreaTag>().Build().GetSingleton() })
                .Set(new AllRoads { List = pathSystem.Roads.ToList() })
                .Set(new AllCrossroads { List = pathSystem.Crossroads.ToList() })
                .Set(new AllPoints { List = new List<PathPoint>() })
                .Set(new AllSpawnPointsGrid { Grid = new Dictionary<(int x, int y), List<PathPoint>>() })
                .Set(new AllSpawnPoints { List = new List<PathPoint>() })
                .Set(new ActiveSpawnPoints { List = new List<PathPoint>() })
                .Set(new HorizonSpawnPoints { List = new List<PathPoint>() })
                .Set(new AllPathLines { List = new List<PathLine>() });
        }
    }
}