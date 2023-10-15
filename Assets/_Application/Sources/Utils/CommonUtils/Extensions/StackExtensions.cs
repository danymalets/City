using System.Collections.Generic;

namespace Sources.Utils.CommonUtils.Extensions
{
    public static class StackExtensions
    {
        public static bool IsEmpty<T>(this Stack<T> stack) =>
            stack.Count == 0;
    }
}