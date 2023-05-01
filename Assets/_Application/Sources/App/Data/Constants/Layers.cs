using UnityEngine;

namespace Sources.App.Data.Constants
{
    public static class Layers
    {
        public static readonly int Player = LayerMask.NameToLayer(nameof(Player));
        public static readonly int Car = LayerMask.NameToLayer(nameof(Car));
        public static readonly int CarBorders = LayerMask.NameToLayer(nameof(CarBorders));
        public static readonly int Environment = LayerMask.NameToLayer(nameof(Environment));
        public static readonly int Ground = LayerMask.NameToLayer(nameof(Ground));
        public static readonly int Props = LayerMask.NameToLayer(nameof(Props));
        public static readonly int Fallen = LayerMask.NameToLayer(nameof(Fallen));
    }
}