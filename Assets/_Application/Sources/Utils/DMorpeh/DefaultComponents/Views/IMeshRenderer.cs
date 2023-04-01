using UnityEngine;

namespace Sources.Utils.DMorpeh.DefaultComponents.Views
{
    public interface IMeshRenderer
    {
        Material Material { get; set; }
        Material SharedMaterial { get; set; }
    }
}