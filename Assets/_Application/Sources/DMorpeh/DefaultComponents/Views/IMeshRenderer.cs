using UnityEngine;

namespace Sources.DMorpeh.DefaultComponents.Views
{
    public interface IMeshRenderer
    {
        Material Material { get; set; }
        Material SharedMaterial { get; set; }
    }
}