using UnityEngine;

namespace Sources.Utils.MorpehWrapper.DefaultComponents.Monos
{
    public interface ISafeSphereCollider
    {
        Vector3 Center { get; set; }
        float Radius { get; set; }
    }
}