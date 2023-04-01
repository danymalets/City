using UnityEngine;

namespace Sources.Utils.Extensions
{
    public static class StringExtensions
    {
        public static int ToAnimatorHash(this string name) =>
            Animator.StringToHash(name);
    }
}