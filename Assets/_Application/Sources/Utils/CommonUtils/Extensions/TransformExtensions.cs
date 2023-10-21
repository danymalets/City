using Sources.Utils.CommonUtils.Libs;
using UnityEngine;

namespace Sources.Utils.CommonUtils.Extensions
{
    public static class TransformExtensions
    {
        public static DBox ToDBox(this Transform transform) =>
            new DBox(transform.position, transform.rotation, transform.lossyScale);
    }
}