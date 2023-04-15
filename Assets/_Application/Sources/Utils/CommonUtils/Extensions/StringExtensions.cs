using UnityEngine;

namespace Sources.Utils.CommonUtils.Extensions
{
    public static class StringExtensions
    {
        public static int ToAnimatorHash(this string name) =>
            Animator.StringToHash(name);
    }
}