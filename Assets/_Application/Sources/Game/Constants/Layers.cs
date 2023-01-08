using Sources.Game.GameObjects.Cars;
using UnityEngine;

namespace Sources.Game.Constants
{
    public static class Layers
    {
        public static readonly int Player = LayerMask.NameToLayer(nameof(Player));
        public static readonly int Car = LayerMask.NameToLayer(nameof(Car));
        public static readonly int EntityTrigger = LayerMask.NameToLayer(nameof(EntityTrigger));
    }
}