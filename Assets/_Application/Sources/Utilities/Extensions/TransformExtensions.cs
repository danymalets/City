using UnityEngine;

namespace Sources.Utilities.Extensions
{
    public static class TransformExtensions
    {
        public static DBox ToDBox(this Transform boxTransform) =>
            new DBox(boxTransform.position, boxTransform.rotation, boxTransform.lossyScale);
    }
}