using Sources.Game.Ecs.Utils;
using UnityEngine;

namespace Sources.Game.Ecs.Components.Views
{
    public interface ICarEngine : IMonoComponent
    {
        Vector3 RootPosition { get; }
        void SetAngleCoefficient(float angleCoefficient);
        void SetMotorCoefficient(float motorCoefficient);
        float Speed { get; }
        void SetMaxBreak();
        void SetLiteBreak();
        void ResetBreak();
    }
}