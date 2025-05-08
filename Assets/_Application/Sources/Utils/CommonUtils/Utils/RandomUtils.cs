using UnityEngine;

namespace Sources.Utils.CommonUtils.Utils
{
    public static class RandomUtils
    {
        public static bool Bool() => 
            Random.Range(0, 2) == 1;
    }
}