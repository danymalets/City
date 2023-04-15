using _Application.Sources.Utils.CommonUtils.Libs;

namespace _Application.Sources.App.Data.Constants
{
    public static class LayerMasks
    {
        public static readonly int Player = DLayerMask.LayerToMask(Layers.Player);
        public static readonly int Car = DLayerMask.LayerToMask(Layers.Car);
        public static readonly int EntityTrigger = DLayerMask.LayerToMask(Layers.Environment);
        public static readonly int CarsAndPlayers = DLayerMask.LayersToMask(Layers.Car, Layers.Player);
        public static readonly int CarsBordersAndPlayers = DLayerMask.LayersToMask(Layers.CarBorders, Layers.Player);
        public static readonly int CarsPlayersEnvironment = DLayerMask.LayersToMask(Layers.Car, Layers.Player, Layers.Environment);
    }
}