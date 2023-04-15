using System.Linq;

namespace Sources.Utils.CommonUtils.Libs
{
    public static class DLayerMask
    {
        public static int Combine(params int[] layerMasks) => 
            layerMasks.Aggregate(0, (current, layer) => current | layer);
        
        public static int LayerToMask(int layer) =>
            (1 << layer);
        
        public static int LayersToMask(params int[] layers) =>
            Combine(layers.Select(LayerToMask).ToArray());
    }
}