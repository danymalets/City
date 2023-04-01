using Sources.Utils.Libs;
using UnityEngine;

namespace Sources.Utils.Extensions
{
    public static class TransformExtensions
    {
        public static DBox ToDBox(this Transform boxTransform) =>
            new DBox(boxTransform.position, boxTransform.rotation, boxTransform.lossyScale);
    }
}