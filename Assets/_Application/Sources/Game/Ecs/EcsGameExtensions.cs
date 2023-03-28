using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehUtils;

namespace Sources.Game.Ecs
{
    public static class EcsWorldGameExtensions
    {
        public static Entity GetUserEntity(this DWorld world) =>
            world.GetSingletonEntity<UserTag>();
    }
}