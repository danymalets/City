using Sources.Utilities;
using UnityEngine;

namespace Sources.Game.Constants
{
    public static class LayerMasks
    {
        public static readonly int Player = DLayerMask.LayerToMask(Layers.Player);
        public static readonly int Car = DLayerMask.LayerToMask(Layers.Car);
        public static readonly int EntityTrigger = DLayerMask.LayerToMask(Layers.EntityTrigger);
    }
}