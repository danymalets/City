using Sources.Utils.CommonUtils.Libs;

namespace Sources.App.Data.Constants
{
    public static class LayerMasks
    {
        public static readonly int Player = LayerMaskUtils.LayerToMask(Layers.Player);
        public static readonly int Car = LayerMaskUtils.LayerToMask(Layers.Car);
        public static readonly int EntityTrigger = LayerMaskUtils.LayerToMask(Layers.Environment);
        public static readonly int CarsAndPlayers = LayerMaskUtils.LayersToMask(Layers.Car, Layers.Player);
        public static readonly int CarsBordersAndPlayers = LayerMaskUtils.LayersToMask(Layers.CarBorders, Layers.Player);
        public static readonly int CarBordersPlayersEnvironment = LayerMaskUtils.LayersToMask(Layers.CarBorders, Layers.Player, Layers.Environment);
    }
}