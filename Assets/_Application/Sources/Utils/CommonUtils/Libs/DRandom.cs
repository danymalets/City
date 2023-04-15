using UnityEngine;

namespace Sources.Utils.CommonUtils.Libs
{
    public static class DRandom
    {
        public static bool Bool() => 
            Random.Range(0, 2) == 1;
    }
}