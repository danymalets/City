using UnityEngine;

namespace Sources.App.Game.Ecs.DefaultComponents.Views
{
    public interface IMeshRenderer
    {
        Material Material { get; set; }
        Material SharedMaterial { get; set; }
    }
}