using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;

namespace Sources.Game.Ecs
{
    public static class EcsWorldGameExtensions
    {
        public static Entity GetUserEntity(this World world) =>
            world.GetSingletonEntity<UserTag>();
    }
}