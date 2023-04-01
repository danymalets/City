using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.Game.Ecs.Components.Collections;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.GameObjects.RoadSystem;
using Sources.App.Game.GameObjects.RoadSystem.Pathes;
using Sources.App.Game.GameObjects.RoadSystem.Pathes.Points;

namespace Sources.App.Game.Ecs.Factories
{
    public class PathesFactory : Factory, IPathesFactory
    {
        public Entity CreatePathes<TTag>(IPathSystem pathSystem) where TTag : struct, IComponent =>
            _world.CreateEntity()
                .Add<TTag>()
                .Add<PathesTag>()
                .Set(new AllRoads { List = pathSystem.Roads.ToList() })
                .Set(new AllCrossroads { List = pathSystem.Crossroads.ToList() })
                .Set(new AllPoints { List = new List<Point>() })
                .Set(new AllSpawnPoints { List = new List<Point>() })
                .Set(new ActiveSpawnPoints { List = new List<Point>() })
                .Set(new HorizonSpawnPoints { List = new List<Point>() })
                .Set(new AllSpawnPoints { List = new List<Point>() })
                .Set(new AllPathLines { List = new List<PathLine>() });
    }
}