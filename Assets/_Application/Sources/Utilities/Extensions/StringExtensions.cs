using UnityEngine;

namespace Sources.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static int ToAnimatorHash(this string name) =>
            Animator.StringToHash(name);
    }
}