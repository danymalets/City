using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sources.Utils.Libs
{
    public static class DBounds
    {
        public static Bounds CombineBounds(IEnumerable<Bounds> bounds)
        {
            Vector3 min = bounds.Select(b => b.min).MinVectorValues();
            Vector3 max = bounds.Select(b => b.max).MaxVectorValues();
            return new Bounds((min + max) / 2, max - min);
        }
    }
}