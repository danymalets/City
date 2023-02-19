using UnityEngine;

namespace Sources.Utilities
{
    public static class DRandom
    {
        public static bool Bool() => 
            Random.Range(0, 2) == 1;
    }
}