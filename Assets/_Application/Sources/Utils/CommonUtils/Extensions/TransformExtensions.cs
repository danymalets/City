using Sources.Utils.CommonUtils.Libs;
using UnityEngine;

namespace Sources.Utils.CommonUtils.Extensions
{
    public static class TransformExtensions
    {
        public static DBox ToDBox(this Transform boxTransform) =>
            new DBox(boxTransform.position, boxTransform.rotation, boxTransform.lossyScale);
    }
}