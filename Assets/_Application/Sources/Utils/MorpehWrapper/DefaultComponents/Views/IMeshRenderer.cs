using UnityEngine;

namespace _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views
{
    public interface IMeshRenderer
    {
        Material Material { get; set; }
        Material SharedMaterial { get; set; }
    }
}