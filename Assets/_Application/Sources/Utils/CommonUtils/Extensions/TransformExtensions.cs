using _Application.Sources.Utils.CommonUtils.Libs;
using UnityEngine;

namespace _Application.Sources.Utils.CommonUtils.Extensions
{
    public static class TransformExtensions
    {
        public static DBox ToDBox(this Transform boxTransform) =>
            new DBox(boxTransform.position, boxTransform.rotation, boxTransform.lossyScale);
    }
}